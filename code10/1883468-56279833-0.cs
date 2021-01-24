    {
        class Person
     {
         public string Name { get; set; }
         public int Age { get; set; }
         public int YearsToWork { get; set; }
     }
      public int YTK(int age)
      {
        {
            int YearsToWork = 65 - Age;
        }
      }
    }
    class Program
    {
      static void Main(string[] args)
      {
        var person = new Person();
        int yearsTillRetire;
        Console.WriteLine("Please enter your name : ");
        Person.Name = Console.ReadLine();
        Console.WriteLine("Please enter your age :  ");
        Person.Age = 
        Convert.ToInt32(Console.ReadLine());
        yearsTillRetire = YearsToWork(person.Age);
        Console.WriteLine("---------------------------- 
         --------------");
        Console.WriteLine("You will work : {0} years 
        before you retire.", yearsTillRetire);
        Console.ReadLine();
      }
    }
