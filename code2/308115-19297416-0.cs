    public static class HashHelper
    {
        public static int InitialHash = 17; // Prime number
        private static int Multiplier = 23; // Different prime number
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int32 GetHashCode<T>( this Int32 source, T next )
        {
            // comparing null of value objects is ok. See
            // http://stackoverflow.com/questions/1972262/c-sharp-okay-with-comparing-value-types-to-null
            if ( next == null )
            {
                return source;
            }
            unchecked
            {
                return source + next.GetHashCode();
            }
        }
    }
