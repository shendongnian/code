    public static T[] GetVerticesFromEdges<T>(Tuple<T, T>[] edges, 
        IEqualityComparer<T> comparer)
    {
        var array = edges.Clone() as Tuple<T, T>[];
        var last = array.Length - 1;
        for (int i = 0; i < last; i++)
        {
            var c = 0;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (comparer.Neighbours(array[i], array[j]))
                {
                    if (!comparer.Equals(array[i].Item2, array[j].Item1))
                    {
                        array[j] = Tuple.Create(array[j].Item2, array[j].Item1);
                    }
                    var t = array[i + 1];
                    array[i + 1] = array[j];
                    array[j] = t;
                    c++;
                    break;
                }
            }
            if (c != 1)
            {
                throw new ArgumentException($"{nameof(edges)} is not a Polygon!");
            }
        }
        if (!comparer.Neighbours(array[last], array[0]))
        {
            throw new ArgumentException($"{nameof(edges)} is not a Polygon!");
        }
        return array.Select(a => a.Item1).ToArray();
    }
