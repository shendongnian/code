    static class typeGetter
    {
        static Type getKnownType&lt;T>(this T it) where T : class
        {
            return typeof(T);
        }
        static String test()
        {
            IEnumerable&lt;System.IO.Stream> myThing = new List&lt;System.IO.MemoryStream>();
            return String.Format("Run-time type {0} but compile-time type {1}",myThing.GetType().ToString(),myThing.getKnownType().ToString());
        }
    }
