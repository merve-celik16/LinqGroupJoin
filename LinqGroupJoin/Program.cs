namespace LinqGroupJoin
{
     class Program
    {
        public class Student //öğrenci sınıfı oluşturuldu
        {
            public int SudentId { get; set; }
            public string Name { get; set; }
            public int ClassId { get; set; }
        }

        public class Class // sınıf adında class oluşturuldu
        {
            public int ClassId { get; set; }
            public string Name { get; set; }
        }
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>() //öğrencileri listeledim
            {
            new Student { SudentId = 1, Name = "Ali", ClassId = 1 },
            new Student { SudentId = 3, Name = "Ayşe", ClassId = 2 },
            new Student { SudentId = 3, Name = "Mehmet", ClassId = 1 },
            new Student { SudentId= 4, Name = "Fatma", ClassId = 3 },
            new Student { SudentId =5, Name = "Ahmet", ClassId = 2 }
             };

            List<Class> classes = new List<Class>() // sınıfı listeledim
            {
            new Class { ClassId = 1, Name = "Matematik" },
            new Class { ClassId = 2, Name = "Türkçe" },
            new Class { ClassId = 3, Name = "Kimya" }
             };
            
            var sonuc = classes.GroupJoin(students, 
                                          classes => classes.ClassId, 
                                          students=> students.ClassId, 
                                          (classes, studentsGroup) => new
            {
                                              Class=classes,
                                              Students=studentsGroup.ToList()
                                          });
            foreach (var item in sonuc)
            {
                Console.WriteLine($"Class: {item.Class.Name}");
                foreach (var student in item.Students)
                {
                    Console.WriteLine($"  Student: {student.Name}");
                }
            }
        }
    }
}
