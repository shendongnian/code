    public class Internals
    {
        private readonly bool IsInitialized;
        
        public Internals(bool initialized)
        {
            IsInitialized = initialized;
        }
    }
    public class SomeBaseClass
    {        
        protected static Internals internals = new Internals(false);
        
        public void SomeFunction()
        {
            do
            {
                Internals previous = internals;
            }while(!previous.IsInitialized && previous != Interlocked.CompareExchange(internals, new Internals(true), previous))
        }
    }
