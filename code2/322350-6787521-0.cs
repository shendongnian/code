    public class ThingA: IMyType
    {
        [Obsolete("This constructor must not be called directly", true)]
        public ThingA()
        {
        }
        public void Initialise(string args)
        {
                // do something with args
        }
    
    }
