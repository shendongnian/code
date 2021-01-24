    var person = new Person();
    Console.WriteLine("Please enter your name : ");
    person.Name = Console.ReadLine();
    Console.WriteLine("Please enter your age :  ");
    person.Age = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("----------------------------------------");
        Console.WriteLine($"You will work : {0} years before you 
    retire.", person.YearsToWork); Console.ReadLine(); } } }
