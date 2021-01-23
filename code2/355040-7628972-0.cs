    public static IEnumerable<T> TakeTopDistinct<T>(this IEnumerable<T> source, int count)
    {
        if (source == null) throw new ArgumentNullException("source");
        if (count < 0) throw new ArgumentOutOfRangeException("count");
        if (count == 0) yield break;
        var comparer = Comparer<T>.Default;
        LinkedList<T> selected = new LinkedList<T>();
        foreach(var value in source)
        {
            if(selected.Count < count // need to fill
                || comparer.Compare(selected.Last.Value, value) < 0 // better candidate
                )
            {
                var tmp = selected.First;
                bool add = true;
                while (tmp != null)
                {
                    var delta = comparer.Compare(tmp.Value, value);
                    if (delta == 0)
                    {
                        add = false; // not distinct
                        break;
                    }
                    else if (delta < 0)
                    {
                        selected.AddBefore(tmp, value);
                        add = false;
                        if(selected.Count > count) selected.RemoveLast();
                        break;
                    }
                    tmp = tmp.Next;
                }
                if (add && selected.Count < count) selected.AddLast(value);
            }
        }
        foreach (var value in selected) yield return value;
    }
