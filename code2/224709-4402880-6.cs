    public static class ArrayHelper
    {
        public static T[] Insert<T>(this T[] source, int index, T item)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
        
            if (index < 0 || index > source.Length)
            {
                throw new ArgumentOutOfRangeException("index");
            }
        
            // Allocate a new array with enough space for one more item.
            T[] result = new T[source.Length + 1];
        
            // Copy all elements before the insertion point.
            for (int i = 0; i < index; ++i)
            {
                result[i] = source[i];
            }
        
            // Insert the new value.
            result[index] = item;
        
            // Copy all elements after the insertion point.
            for (int i = index; i < source.Length; ++i)
            {
                result[i + 1] = source[i];
            }
        
            return result;
        }
    }
