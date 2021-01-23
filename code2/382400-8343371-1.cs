    string begroeting;
    while(begroeting.ToLower() != "some string you want to stop loop execution")
    {
       Console.WriteLine("Hi."); 
        string eersteAntwoord = Console.ReadLine(); 
        if (eersteAntwoord == "Hi" || eersteAntwoord == "hi") 
        { 
            Console.WriteLine("How are you doing?"); 
            begroeting = Console.ReadLine(); 
            if (begroeting == "I'm good") 
            { 
                Console.WriteLine("Good"); 
                break; // this would be if you want to get out of your loop
            } 
            else if (begroeting == "hi") 
            { 
                Console.WriteLine(""); 
                continue; // go to the next iteration of the while loop
            }
        }
    }
