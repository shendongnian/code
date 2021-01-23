    public static void RemoveConsecutiveDuplicates<T>(this List<T> collection)
    {
        for (int i = 0; i < collection.Count - 1; i++)
        {
            if (collection[i].Equals(collection[i + 1]))
            {
                collection.RemoveAt(i);
                i--;
            }
        }
    }
    var collection = new [] { 2, 7, 7, 7, 2, 6, 4 }.ToList();
    collection.RemoveConsecutiveDuplicates();
