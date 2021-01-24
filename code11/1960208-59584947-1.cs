    bool ok;
    do
    {
        Console.Write("Please enter a x value:");
        if (ok = double.TryParse(Console.ReadLine(),out x))
        {
    
        }
        else
        {
            Console.WriteLine("You have entered wrong value. Please try again.");
        }
    } while (!ok);
