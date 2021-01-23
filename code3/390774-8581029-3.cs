    // Assembly Echo
    class Foxtrot
    {
        static void M(Action<Charlie> f) {}
        static void M(Action<Delta> f) {}
        static void Golf()
        {
            int x = M(y=>{y.P = 123;});
        }
    }
