    public static T RandomElement<T>(this IEnumerable<T> source,
                                     Random random)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
        if (random == null)
        {
            throw new ArgumentNullException("random");
        }
        ICollection collection = source as ICollection;
        if (collection != null)
        {
            int count = collection.Count;
            if (count == 0)
            {
                throw new InvalidOperationException("Sequence was empty.");
            }
            int index = random.Next(count);
            return source.ElementAt(index);
        }
        ICollection<T> genericCollection = source as ICollection<T>;
        if (genericCollection != null)
        {
            int count = genericCollection.Count;
            if (count == 0)
            {
                throw new InvalidOperationException("Sequence was empty.");
            }
            int index = random.Next(count);
            return source.ElementAt(index);
        }
        using (IEnumerator<T> iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                throw new InvalidOperationException("Sequence was empty.");
            }
            int countSoFar = 1;
            T current = iterator.Current;
            while (iterator.MoveNext())
            {
                countSoFar++;
                if (random.Next(countSoFar) == 0)
                {
                    current = iterator.Current;
                }
            }
            return current;
        }
    }
