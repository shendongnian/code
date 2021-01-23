    public class ClassA
    {
        public event EventHandler Finished;
    
        public ClassA() {}
    
        public void Animate()
        {
            Console.WriteLine("ClassA instance animating.");
            if (Finished != null)
                Finished(this, null);
        }
    }
    
    public class ClassB
    {
        public ClassB() {}
    
        public void DoWork()
        {
            Console.WriteLine("ClassB instance doing work.");
        }
    }
