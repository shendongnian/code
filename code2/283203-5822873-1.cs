    public class Internals
    {
        protected volatile bool IsInitialized = false; // Make it a volatile
        
        public Internals(bool initialized)
        {
            IsInitialized = initialized;
        }
    }
    public class SomeBaseClass
    {        
        private static Internals internals = new Internals(false);
        
        public void SomeFunction()
        {
            do
            {
                Internals previous = internals;
            }while(!previous.IsInitialized && previous != Interlocked.CompareExchange(internals, new Internals(true), previous))
        }
    }
