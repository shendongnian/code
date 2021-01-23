        internal static class Extensions
        {
            // Artificial example!
            public static int GetNameLength(this FooDTO foo)
            {
                return foo.Name.Length;
            }
        }
        
        // Consuming code
        int myFooNameLength =  myFooDTO.GetNameLength();
