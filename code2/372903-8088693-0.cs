        static void Main()
        {
            // Create an object, but don't set attribute.
            Foo foo = new Foo();
            if (!foo.BatchValuation)
                Console.WriteLine("BatchValuation is False");
            else
                Console.WriteLine("BatchValuation is True");
            Console.ReadKey();
        }
    }
    // Test class.
    public class Foo
    {
        private bool _batchValuation;
        public Foo() { }
        public bool BatchValuation 
        {
            get { return _batchValuation; }
            set { _batchValuation = value; }
        }
    }
