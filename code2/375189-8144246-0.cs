    class A<T>
    {
        private static int Counter {
            get {
                ACounter.Increment();
                return ACounter.counter;
            }
        }
        
        public int Index;
        
        public A()
        {
           this.Index = Counter;
           
           Console.WriteLine(this.Index);
        }
    }
    
    static class ACounter
    {
        static ACounter() {
            counter = 0;
        }
        public static int counter {get; private set;};
        
        public static void Increment() {
            counter++;
        }
    }
