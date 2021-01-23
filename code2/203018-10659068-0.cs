    public static class List
    {
        public static IList<T> Empty<T>()
        {
            // Note that the static type is only instantiated when
            // it is needed. Once the Array property has been retrieved,
            // its value is stored in the static variable in the class.
            return EmptyArray<T>.Array;
        }
        private class EmptyArray<T>
        {
            private static T[] array = null;
            public static T[] Array
            {
                get { return array ?? (array = new T[0]); }
            }
        }
    }
