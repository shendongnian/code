    public static int[] FindAllIndexes<T>(this IEnumerable<T> source, Func<T,bool> predicate)
    {
         //do necessary check here, then
         Queue<int> indexes = new Queue<int>();
         for (int i = 0;i<source.Count();i++)
               if (predicate(source.ElementAt(i))) indexes.Enqueue(i);
         return indexes.ToArray();
    }
