    class foo
    {
        public static IDisposable factory()
        {
            return null;
        }
    }
    
    using (var disp = foo.factory())
    {
        //do some stuff
    }
