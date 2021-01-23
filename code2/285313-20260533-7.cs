    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentsList  = new List<Student>();
            studentsList .Add(new Student { ID = 101, Name = "Rita", grade = 99 });
            studentsList .Add(new Student { ID = 102, Name = "Mark", grade = 48 });
            Student.failed(studentsList, std => std.grade < 60);  // with Lamda
              }
           }
