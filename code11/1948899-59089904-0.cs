    class Program
    {
        static int test = 5;
        static bool trigger = true;
        static void Main(string[] args)
        {
            if (trigger)
            {
                mod_test();
            }
        }
        public static void mod_test()
        {
            test++;
            trigger = false;
        }
    }
