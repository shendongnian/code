    class Program
    {
        static void Main(string[] args)
        {
            using (UtilityClass utilityClass = new UtilityClass()) // To dispose after the use
            {
                System.Threading.Thread.Sleep(10000 * 60); // Waits X milliseconds
            }
        }
    }
