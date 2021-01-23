    public class MyRandom
    {
        public Random Random { get; private set; }
    
        public MyRandom()
        {
            // Is this ambiguous? No--the left HAS to be the property;
            // the right HAS to be the type name.
            Random = new Random();
        }
    }
