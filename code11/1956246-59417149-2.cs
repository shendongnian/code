    public static class Program
    {
        public static void Main(string[] args)
        {
          var students = new[]
          {
            new Student { Name = "Enrico", Age = 32 },
            new Student { Name = "Alice", Age = 18 },
            new Student { Name = "Enrico", Age = 40 }
          };
    
          foreach (var student in students.Distinct(new StudentComparerByName()))
          {
            Console.WriteLine($"{student.Name} is {student.Age}");
          }
    
          Console.ReadLine();
        }
      }
