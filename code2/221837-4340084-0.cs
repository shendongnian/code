    public static T[] ToArray<T>(this IEnumerable<T> source)
    {
        T[] items = null;
        int count = 0;
    
        foreach (T item in source)
        {
            if (items == null)
            {
                items = new T[4];
            }
            else if (items.Length == count)
            {
                T[] destinationArray = new T[count * 2];
                Array.Copy(items, 0, destinationArray, 0, count);
                items = destinationArray;
            }
            items[count] = item;
            count++;
        }
      
        if (items.Length == count)
        {
            return items;
        }
        T[] destinationArray = new TElement[count];
        Array.Copy(items, 0, destinationArray, 0, count);
        return destinationArray;
    }
