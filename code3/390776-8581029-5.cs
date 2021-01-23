    // Assembly Echo
    class Foxtrot
    {
        static void M(Action<Charlie> f) {}
        static void M(Action<Delta> f) {}
        static void Golf()
        {
            M(y=>{y.P = 123;});
        }
    }
