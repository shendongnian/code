    public class SomeClass
    {
        public SomeClass()
        {
            InstanceCounter<SomeClass>.Increase();        
        }
    
        ~SomeClass()
        {
            InstanceCounter<SomeClass>.Decrease();
        }
    }
