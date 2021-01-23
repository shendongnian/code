    public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(
        this IEnumerable<IEnumerable<T>> sequences)
    {
        var accum = new List<T[]>();
        var list = sequences.ToList();
        if (list.Count > 0)
        {
            var enumStack = new Stack<IEnumerator<T>>();
            var itemStack = new Stack<T>();
            int index = list.Count - 1;
            var enumerator = list[index].GetEnumerator();
            while (true)
                if (enumerator.MoveNext())
                {
                    itemStack.Push(enumerator.Current);
                    if (index == 0)
                    {
                        accum.Add(itemStack.ToArray());
                        itemStack.Pop();
                    }
                    else
                    {
                        enumStack.Push(enumerator);
                        enumerator = list[--index].GetEnumerator();
                    }
                }
                else
                {
                    if (++index == list.Count)
                        break;
                    itemStack.Pop();
                    enumerator = enumStack.Pop();
                }
        }
        return accum;
    }
