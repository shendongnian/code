        for (int i = 0; i < 5; i++)
    {
        
        Console.WriteLine("Please enter a number");
        string listS = Console.ReadLine();
        //avoid problems with empty or nullstrings
        if(!String.IsNullOrEmpty(listS))
        {
          list.Add(listS);
        }
    }
