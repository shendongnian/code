    string userInput = Console.ReadLine(); 
    if (int.TryParse(userInput, out int choice)) 
    {
        switch(choice)
        {
            //etc
        }
    
    }
    else 
    {
        Console.WriteLine("Invalid - Choice not a numeric response");
    }
