    public class SomeClass
    {
        public SomeClass()
        {
            InstanceCounter<SomeClass>.Increase();        
        }
    
        public ~SomeClass()
        {
            InstanceCounter<SomeClass>.Decrease();
        }
    }
