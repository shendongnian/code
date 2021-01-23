    float[] ArrayAverage(params float[][] arrays)
    {
        // If you want to check that all arrays are the same size, something
        // like this is convenient:
        // var arrayLength = arrays.Select(a => a.Length).Distinct().Single();
        return Enumerable.Range(0, arrays[0].Length)
                   .Select(i => arrays.Select(a => a.Skip(i).First()).Average())
                   .ToArray();
    }
