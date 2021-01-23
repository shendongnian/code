    bool success = false;
    
    while(!success)
    {
        try
        {
            Console.WriteLine("Please enter a name:");
            myObject.Name = Console.ReadLine();
            success = true;
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
