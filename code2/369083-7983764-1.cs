    // file 1
    namespace A
    {
        public class B
        {
            public void SomeMethod()
            { ... } 
        }
    }
    // file 2
    namespace A
    {
        public static class BExtensions
        {
            public static void SomeNewMethod(this B source)
            {
                // perform action on B
            }
        }
    }
