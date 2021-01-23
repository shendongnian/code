    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            a.MaximumNumberReached();
        }
    }
    
    public static class Extns
    {
        public static void MaximumNumberReached(this int number)
        {
            if (number == 7)
            {
                //Do something
            }
        }
    }
