    static void LoggingThread()
    {
        using (var w = new StreamWriter(...))
        {
            while (!LogQueue.IsCompleted())
            {
                Step item;
                if (LogQueue.TryTake(out item))
                {
                    w.WriteLine(....);
                }
            }
        }
    }
