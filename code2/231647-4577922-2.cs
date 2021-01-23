    static IEnumerable<T> MergeShuffle<T>(IEnumerable<T> lista, IEnumerable<T> listb)
    {
        var first = lista.GetEnumerator();
        var second = listb.GetEnumerator();
        var rand = new Random();
        bool exhaustedA = false;
        bool exhaustedB = false;
        while (!(exhaustedA && exhaustedB))
        {
            bool found = false;
            if (!exhaustedB && (exhaustedA || rand.Next(0, 2) == 0))
            {
                 exhaustedB = !(found = second.MoveNext());
                if (found)
                    yield return second.Current;
            }
            if (!found && !exhaustedA)
            {
                exhaustedA = !(found = first.MoveNext());
                if (found)
                    yield return first.Current;
            }
        }                
    }
