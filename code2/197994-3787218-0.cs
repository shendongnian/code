    interface IFoo
    {
        int Count { get; set; }
        event EventHandler SomeEvent;
    }
    
    class Foo : IFoo
    {
        public int Count
        {
            get 
            {
                Console.WriteLine("Count.get called!");
                return 0;
            }
            set
            {  
                Console.WriteLine("Count.set called with value {0}", value);
            }
        }
        
        public event EventHandler SomeEvent
        {
            add
            {
                Console.WriteLine("SomeEvent.add called");
            }
            remove
            {
                Console.WriteLine("SomeEvent.remove called");
            }
        }
    }
    
    class Test
    {
        
        static void Main()
        {
            IFoo f = new Foo();
            int x = f.Count;
            f.Count = 5;
            f.SomeEvent += delegate {};
            f.SomeEvent -= delegate {};
        }
    }
