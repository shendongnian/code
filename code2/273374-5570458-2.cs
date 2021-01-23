    if (selec == "1")
    {
       ...
       Console.WriteLine("Enter Name");
       string name = Console.ReadLine();
       Console.WriteLine("Enter Surname");
       string surname = Console.ReadLine();
       Console.WriteLine("Enter Age");
       int age = Convert.ToInt32(Console.ReadLine());
       Students regstud = new Students(name, surename, id, age);
       ...
    }
