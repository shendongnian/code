    class C
    {
        static DynamicCallSite FooCallSite;
        void M()
        {
            object d1 = whatever;
            object d2;
            if (FooCallSite == null) FooCallSite = new DynamicCallSite();
            d2 = FooCallSite.DoInvocation("Foo", d1);
