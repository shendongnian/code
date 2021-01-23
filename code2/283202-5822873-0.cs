    public class Internals
    {
        protected static volatile bool IsInitialized = false; // Make it a volatile
        private State _objecState;
        
        public Internals(bool initialized)
        {
            IsInitialized = initialized;
        }
    }
    public class SomeBaseClass
    {        
        private static Internals internals;
        public void SomeBasicClass()
        {
            internals = new Internals(true);
        }
        
        public void SomeFunction()
        {
            do
            {
                Internals previous = internals;
            }while(!previous.IsInitialized && previous != Interlocked.CompareExchange(internals, new Internals(true), previous))
        }
    }
