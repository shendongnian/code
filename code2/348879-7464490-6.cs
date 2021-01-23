    public void RunSimulation()
    {
        while(running)
        {
            // Puts the thread to sleep depending on the run speed
            Thread.Sleep(delayTime);
            Console.WriteLine("Write your output to console!");
        }
    }
