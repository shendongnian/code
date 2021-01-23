    public static class Foo
    {
        private static readonly Destructor Finalise = new Destructor();
        
        static Foo()
        {
            // One time only constructor.
        }
        
        private sealed class Destructor
        {
            ~Destructor()
            {
                // One time only destructor.
            }
        }
    }
