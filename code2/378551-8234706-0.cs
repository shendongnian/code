        static void Main(string[] args)
        {
            MyMethod(null);
            MyMethod(0);
        }        
        public static dynamic MyMethod(dynamic value)
        {
            if (value != null)
                Console.WriteLine("Value is not null.");
            if (value != 0)
                Console.WriteLine("Value is not 0.");
            return value;
        }
