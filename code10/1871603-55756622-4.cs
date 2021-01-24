    class Program
    {
        static void Main(string[] args)
        {
            using (UtilityClass utilityClass = new UtilityClass()) // To dispose after the use
            {
                while (true) { }
            }
        }
    }
