    public static class HasDisposableThreadStaticThing
    {
        [ThreadStatic]
        public static DisposableThing Foo;
        public static void UseDisposableThing()
        {
            try
            {
                using (Foo = new DisposableThing())
                {
                    Foo.DoSomething();
                }
            }
            finally
            {
                Foo = null;
            }
        }
    }
