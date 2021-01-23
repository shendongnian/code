    using ClassLibraryC;
    namespace ClassLibraryB
    {
        public static class Extensions
        {
            public static ClassC Test(this ClassB b)
            {
                return new ClassC();
            }
        }
        public class ClassB
        {
        }
    }
