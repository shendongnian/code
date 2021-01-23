    public static class ExtensionMethods
    {
        // An extension method to remove an index from an array, it works with any value type
        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            if (index < 0 || index > source.Length)
                throw new IndexOutOfRangeException();
            if (source == null)
                throw new ArgumentNullException();
            T[] dest = new T[source.Length - 1];
            if (index != 0)
                Array.Copy(source, 0, dest, 0, index - 1);
            if (index != source.Length)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);
            return dest;
        }
    }
