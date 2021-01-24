    string name;
    while (true) { 
        Console.Write("Enter your name:");
        name = Console.ReadLine();
        bool isEmpty = string.IsNullOrEmpty(name);
        bool isIntString = name.All(char.IsDigit);
        bool containsInt = name.Any(char.IsDigit);
        if (isEmpty)
        {
            Console.WriteLine("Name cannot be empty");
        }
        else if(isIntString)
        {
            Console.WriteLine("Your name cannot be made up of numbers");
        }
        else if (containsInt)
        {
            Console.WriteLine("Your name cannot contain numbers");
        }
        else
        {
           Console.WriteLine("Name filled");
           break;
        }
    }
    Console.WriteLine("Your name is: " + name);
    Console.ReadKey();
