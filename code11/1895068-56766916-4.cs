    for (int i = 0; i < threadsCount; i++)
    {
        // Capture the counters to make sure no lambda pitfall
        int counterI = i;
        int counterJ = j;
        
        Thread thread = new Thread(() =>
        {                                
            Console.WriteLine("i value: {0}", counterI);
            Console.WriteLine("j value: {0}", counterJ);
    
            // your code                    
        }
    }
