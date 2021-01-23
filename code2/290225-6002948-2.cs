    using C;
    
    namespace B
    {
        public static class Extensions
        {
            public static string ExtMethodB<T>(this T cInstance) where T : ClassC
            {
                return cInstance.Foo;
            }
        }
    }
