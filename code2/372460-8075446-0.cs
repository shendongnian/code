    public static IEnumerable<Http> enumurate()
    {
        IEnumerator e = cache.Keys.GetEnumerator();
        while (e.MoveNext())/*While e has more element*/
        {
            var vector = (List<Http>)cache[e.Current];
            for (int i = 0; i < vector.Count; i++)
            {
                yield vector.ElementAt<Http>(i);
            }
        }
    }
