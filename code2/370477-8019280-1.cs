        class xxx
        {
            private xxx() :
                this(10)
            {
            }
            public xxx(int value)
            {
                Console.WriteLine(value);
            }
        }
        static void Main(string[] args)
        {
            Activator.CreateInstance(typeof(xxx), true);
            Console.ReadLine();
        }
