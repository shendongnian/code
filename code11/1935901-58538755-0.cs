        class Program
        {
            static void Main(string[] args)
            {
                List<Student> students = new List<Student>();
                var teachers = students.SelectMany(x => x.teachers.Select(y => new { 
                    studentName = x.Name,
                    studentAge = x.Age,
                    teacherName = y.Name,
                    teacherAge = y.Age
                }))
                .GroupBy(x => x.teacherName)
                .ToList();
            }
        }
        public class Student
        {
        
            public string Name { get;set;}
            public int Age { get;set;}
            public List<Teacher> teachers { get;set;}
        }
        public class Teacher
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
