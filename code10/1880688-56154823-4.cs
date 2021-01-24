    public class Student
    {
       public string Name {get;set;}
       public int Score {get;set;}
    }
    public class Program
    {
       public static void Main(string[] args)
       {
           List<Student> Students = new List<Student>();
           
           for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Please enter a students name");
                string name = Console.ReadLine();
                Console.WriteLine("Please enter marks");
                var score = int.Parse(Console.ReadLine());
                
                Students.Add(new Student(){Name = name, Score = score});
            }
           
           var result = Students.Where(x => x.Score < 40).ToList();
           foreach(var item in result)
           {
              Console.WriteLine($"Name : {item.Name} and Score : {item.Score}");
           }
           Console.ReadLine();
       }
    }
