    public static class ConsoleReader
    {
        public static ConsoleReadType<T> GetReader<T>()
        {
            if (typeof(T) == typeof(double))
            {
                return new ConsoleReadDouble();
            }
            // etc
        }
    }
