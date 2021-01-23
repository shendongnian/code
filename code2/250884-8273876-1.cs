        static void Main(string[] args)
        {
          
          List<Student> listStudents = new List<Student>();
          listStudents.Add(new Student() { Grade = 10, Name = "Pedro" });
          listStudents.Add(new Student() { Grade = 10, Name = "Luana" });
          listStudents.Add(new Student() { Grade = 10, Name = "Maria" });
          listStudents.Add(new Student() { Grade = 11, Name = "Mario" });
          listStudents.Add(new Student() { Grade = 15, Name = "Mario" });
          listStudents.Add(new Student() { Grade = 10, Name = "Bruno" });
          listStudents.Add(new Student() { Grade = 10, Name = "Luana" });
          listStudents.Add(new Student() { Grade = 11, Name = "Luana" });
          listStudents.Add(new Student() { Grade = 22, Name = "Maria" });
          listStudents.Add(new Student() { Grade = 55, Name = "Bruno" });
          listStudents.Add(new Student() { Grade = 77, Name = "Maria" });
          listStudents.Add(new Student() { Grade = 66, Name = "Maria" });
          listStudents.Add(new Student() { Grade = 88, Name = "Bruno" });
          listStudents.Add(new Student() { Grade = 42, Name = "Pedro" });
          listStudents.Add(new Student() { Grade = 33, Name = "Bruno" });
          listStudents.Add(new Student() { Grade = 33, Name = "Luciana" });
          listStudents.Add(new Student() { Grade = 17, Name = "Maria" });
          listStudents.Add(new Student() { Grade = 25, Name = "Luana" });
          listStudents.Add(new Student() { Grade = 25, Name = "Pedro" });
          listStudents.GroupBy(g => g.Name).OrderBy(g => g.Key).SelectMany(g => g.OrderByDescending(x => x.Grade)).ToList().ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
