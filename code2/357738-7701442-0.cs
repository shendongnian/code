    static void Test()
    {
        bool exit = true;
        string answer = "";
        do
        {
	        Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            switch (name)
            {
                case "name":
                    Console.WriteLine("Hello Name");
                    break;
                case "name2":
                    Console.WriteLine("Hello Name2");
                    break;
            }
            Console.WriteLine("Would you like to enter a new name? y/n: ");
            answer = Console.ReadLine();
            if (answer == "y")
                exit = false;
            else
                exit = true;
        }
        while (!exit);
    }
