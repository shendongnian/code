    class Program
    {
        static void Main(string[] args)
        {
            StringHolder.ImportantString = "Howdy";
            var x = Singleton.Current;
            Console.WriteLine("Done");
        }
    }
    public class Singleton
    {
        public static Singleton Current { get; } = new Singleton();
        private Singleton()
        {
            try
            {
                Console.WriteLine("Calling ctor.");
                var x = StringHolder.ImportantString.ToLower(); // Null Reference occurs here when Optimize Code is on.
                Console.WriteLine("ctor called.");
            }
            catch(Exception e)
            {
                Console.WriteLine($"ctor failed with {e.GetType()}");
            }
        }
    }
    public static class StringHolder
    {
        private static string importantString;
        public static string ImportantString
        {
            get
            {
                Console.WriteLine("Getting ImportantString");
                return importantString;
            }
            set
            {
                Console.WriteLine("Setting ImportantString");
                importantString = value;
                Console.WriteLine("ImportantString set");
            }
        }
    }
