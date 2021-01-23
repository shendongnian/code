    float[] ArrayAggregate(Func<IEnumerable<float>, float> aggregate, params float[][] arrays)
    {
        return Enumerable.Range(0, arrays[0].Length)
                   .Select(i => aggregate(arrays.Select(a => a.Skip(i).First())))
                   .ToArray();
    }
