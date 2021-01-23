    class Testo
    {
        public const string MyValue = "Hello, world";
        public static readonly int xyzzy;
        static Testo()
        {
            Console.WriteLine("In static constructor");
            xyzzy = 27;
        }
    }
