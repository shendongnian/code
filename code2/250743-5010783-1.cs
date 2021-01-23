    public static T[][] ToJaggedArray<T>(this T[,] arr)
    {
        return Enumerable.Range(0, arr.GetUpperBound(0) + 1)
                         .Select(i => Enumerable.Range(0, arr.GetUpperBound(1) + 1)
                                                .Select(j => arr[i, j])
                                                .ToArray())
                         .ToArray();
    }
    public static T[][] ToJaggedArrayTranspose<T>(this T[,] arr)
    {
        return Enumerable.Range(0, arr.GetUpperBound(1) + 1)
                         .Select(j => Enumerable.Range(0, arr.GetUpperBound(0) + 1)
                                                .Select(i => arr[i, j])
                                                .ToArray())
                         .ToArray();
    }
    // you'd be interested in ToJaggedArrayTranspose()
    var mat = new[,]
    {
        {1, 2, 3},
        {4, 5, 6},
        {7, 8, 9},
    };
    var arr = mat.ToJaggedArrayTranspose();
    // arr === new[][] { new[] {1, 4, 7}, new[] {2, 5, 8}, new[] {3, 6, 9} }
