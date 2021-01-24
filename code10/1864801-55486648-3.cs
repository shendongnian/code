    using System;
    public static class MyExtensions
    {
        public static int SomeMethod(this int[] source)
        {
            ThrowIfNull(source, nameof(source));
    
            return 42;
        }
    
        private static void ThrowIfNull(object value, string parameter)
        {
            if (value == null)
                throw new ArgumentNullException(parameter);
        }
    }
