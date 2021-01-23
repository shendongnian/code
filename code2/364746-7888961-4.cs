    private IEnumerable<Tuple<int, int>> Pack(IEnumerable<bool> source)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        using (var iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                yield break;
            }
            bool current = iterator.Current;
            int index = 0;
            int length = 1;
            while (iterator.MoveNext())
            {
                if(current != iterator.Current)
                {
                    yield return Tuple.Create(index, length);
                    index += length;
                    length = 0;
                }
                current = iterator.Current;
                length++;
            }
            yield return Tuple.Create(index, length);
        }
    }
