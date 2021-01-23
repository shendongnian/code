    class Program
    {
        static void Main()
        {
            // no need of try/catch here as exceptions won't propagate to here
            Looper();
        }
    
        static void Looper()
        {
            int processedRecords = 0;
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Thrower(i);
                    processedRecords++;
                }
                catch (NullReferenceException ex)
                { }
            }
            // prints 5 as expected
            Console.WriteLine("processed {0} records", processedRecords);
        }
    
        static void Thrower(int i)
        {
            if (i % 2 == 0)
            {
                throw new NullReferenceException();
            }
        }
    }
