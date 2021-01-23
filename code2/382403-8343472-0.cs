            Console.WriteLine("Hi.");
            string eersteAntwoord = Console.ReadLine();
            if (eersteAntwoord.Equals("hi", StringComparison.OrdinalIgnoreCase))
            {
                 while(!HowAreYouDoing());
            }
    bool howAreYouDoing()
    {
        Console.WriteLine("How are you doing?");
        string begroeting = Console.ReadLine();
        
        if (begroeting == "I'm good")
        {
            Console.WriteLine("Good");
            return true;
        }
        else if (begroeting == "hi") 
        {
            Console.WriteLine("You hurt your hand.");
            return false;
        }
    }
                
