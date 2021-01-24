    static int[,,] Expand(int[] array, int[] size)
    {
        var res = Array.CreateInstance(typeof(int), size);
        for (var i = 0; i < array.Length; i++)
            res.SetValue(array[i], GetMultidimensionalIndex(i, size));
        return (int[,,])res;
    }
    static int[] GetMultidimensionalIndex(int index, int[] size)
    {
        var factors = size.Select((item, i) => size.Skip(i).Aggregate((a, b) => a * b)).ToArray();
        var factorsHelper = factors.Zip(factors.Skip(1).Append(1), (Current, Next) => new { Current, Next }).ToArray();
        return factorsHelper.Select(item => index % item.Current / item.Next).ToArray();
    }
