        Console.Write(20);
        string line = Console.ReadLine();
        int number, myAge = 0;
        if (int.TryParse(line, out number))
            myAge = number + 10;
        Console.WriteLine(myAge);
