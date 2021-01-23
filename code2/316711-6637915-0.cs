    public static int GetIndex<T>(this IEnumerable<T> lst, T obj, int index)
    {
    	return lst.Select((o, i) => new { o, i })
                  .Where(x => x.o.Equals(obj))
                  .ElementAt(index - 1)
                  .i;
    }
