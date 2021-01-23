    // Assembly Echo
    class Foxtrot
    {
        static void M(Func<Charlie, int> f) {}
        static void M(Func<Delta, int> f) {}
        static void Golf()
        {
            int x = M(y=>y.P);
        }
    }
