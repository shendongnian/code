    public static class Array<T>
    {
        public static T[] Empty()
        {
            return Empty(0);
        }
        public static T[] Empty(int size)
        {
            return new T[size];
        }
    }
