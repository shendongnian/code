    class Program
    {
        static void Main(string[] args)
        {
            foo f = new foo();
            MemoryLeak.ActivateLeak += o => f.bar();
            f.tryCleanup();
        }
    }
    
    class foo
    {
        public void bar()
        { }
    
        public void tryCleanup()
        {
            MemoryLeak.ActivateLeak -= o => bar();
        }
    }
