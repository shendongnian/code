    public static class HasDisposableThreadStaticThing
    {
        public static void UseDisposableThing()
        {
            using (var foo = new DisposableThing())
            {
                foo.DoSomething();
            }
        }
    }
