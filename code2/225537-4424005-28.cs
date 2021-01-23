    public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(
        this IEnumerable<IEnumerable<T>> sequences)
    {
        var accum = new List<T[]>();
        var list = sequences.ToList();
        if (list.Count > 0)
            CartesianRecurse(accum, new Stack<T>(), list, list.Count - 1);
        return accum;
    }
    static void CartesianRecurse<T>(List<T[]> accum, Stack<T> stack,
                                    List<IEnumerable<T>> list, int index)
    {
        foreach (T item in list[index])
        {
            stack.Push(item);
            if (index == 0)
                accum.Add(stack.ToArray());
            else
                CartesianRecurse(accum, stack, list, index - 1);
            stack.Pop();
        }
    }
