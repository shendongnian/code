        public static void Main(string[] args)
        {
            ImmutableFoo foo = new ImmutableFoo.Builder()
                .SetSomeValue("Assil is my name")
                .Build();
            Console.WriteLine(foo.SomeValue);
            Console.WriteLine("Hit enter to terminate");
            Console.ReadLine();
        }
    }
