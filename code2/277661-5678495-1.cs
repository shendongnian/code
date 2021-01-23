    TimedGate updateGate = new TimedGate(TimeSpan.FromMilliseconds(100);
    private void update()
    {
        if(updateGate.TryEnter())
        {
            Console.WriteLine("!update");
            // do work here
        }
        else
        {
            Console.WriteLine("!skip update");
        }
    }
