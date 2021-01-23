    string input;
    
    do
    {
        Console.WriteLine("Input your text (type EXIT to terminate): ");
        input = Console.ReadLine();
        
        if (input.ToUpper() != "EXIT")
        {
            // do something with the input
        }
    } while (input.ToUpper() != "EXIT");
