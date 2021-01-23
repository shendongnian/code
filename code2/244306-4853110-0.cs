    class Program
    {
        static T Retry<T, TException>(Func<T> thingToTry, int timesToRetry)
            where TException : Exception
        {
            try
            {
                return thingToTry();
            }
            catch (TException)
            {
                // Recursive call, decrementing retry counter.
                if (timesToRetry > 0) return Retry<T, TException>(thingToTry, timesToRetry - 1);
                throw;
            }
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
