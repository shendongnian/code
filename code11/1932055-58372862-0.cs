    Random slumpat = new Random(); 
    int speltal = slumpat.Next();
    bool spela = true; 
   
    //DONE: while (spela) - we loop while spela == true
    // In your current implementation while never runs
    while (spela)
    {
        Console.Write("\n\Gissa på ett tal mellan 1 och 20: ");
        int tal = Convert.ToInt32(Console.ReadLine());
    
        if (tal < speltal)
        {
            Console.WriteLine("\tDet inmatade talet " + tal + " är för litet, försök igen.");
        }
    
        if (tal > speltal)
        {
            Console.WriteLine("\tDet inmatade talet " + tal +  " är för stort, försök igen.");
        }
    
        if (tal == speltal)
        {   //DONE: braces - you wnat to show the message AND change spela to false 
            
            Console.WriteLine("\tGrattis, du gissade rätt!");
            spela = false;
        }
    }
