    public static TOutput[,] ConvertAll<TInput, TOutput>(
        this TInput[,] array, Func<TInput, TOutput> converter)
    {
        int length0 = array.GetLength(0);
        int length1 = array.GetLength(1);
        var result = new TOutput[length0, length1];
        for (int i = 0; i < length0; i++)
            for (int j = 0; j < length1; j++)
                result[i, j] = converter(array[i, j]);
        return result;
    }
