    class Program
    {
        static T Retry<T, TException>(Func<T> thingToTry, int timesToRetry)
            where TException : Exception
        {
            // Start at 1 instead of 0 to allow for final attempt
            for (int i = 1; i < timesToRetry; i++)
            {
                try
                {
                    return thingToTry();
                }
                catch (TException)
                {
                    // Maybe: Trace.WriteLine("Failed attempt...");
                }
            }
            return thingToTry(); // Final attempt, let exception bubble up
        }
        static int ServiceCall()
        {
            if (DateTime.Now.Ticks % 2 == 0)
            {
                throw new InvalidOperationException("Randomly not working");
            }
            return DateTime.Now.Second;
        }
        static void Main()
        {
            int s = Retry<int, InvalidOperationException>(ServiceCall, 10);
        }
    }
