    void Main()
    {
        var cookies = new IAsyncResult[10];
        Action action = delegate
        {
            // I'm going to print out a bunch of numbers here
            for (int i = 0; i < 100; ++i)
                Console.WriteLine(i);
        }
    
        for (int i = 0; i < cookies.Length; ++i)
            cookies[i] = action.BeginInvoke(null, null);
    
        // with all 10 threads executing, you'll see numbers print out in some crazy,
        // unpredictable order...this line will come out somewhere in the mess (or maybe
        // before it...who knows?)
        Console.WriteLine("All threads started!");
    
        // we wait for each of the workers to finish executing here:
        foreach (var c in cookies)
            action.EndInvoke(c);
        
        // and this will always be printed last, thereby demonstrating that EndInvoke
        // causes the calling thread to wait for the action to finish
        Console.WriteLine("Done!");
    }
