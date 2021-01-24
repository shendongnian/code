    /// <summary>
    /// Copy all elements of the native array into a packed array. Elements are arranged row-by-row.
    /// For example <c>[1,2 | 3,4] => [1,2,3,4]</c>
    /// </summary>
    /// <param name="matrix">The native array</param>
    /// <returns>The packed array</returns>
    public static double[] ToPackedArray(this double[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        double[] result = new double[n*m];
        Buffer.BlockCopy(matrix, 0, result, 0, Buffer.ByteLength(result));
        return result;
    }
    /// <summary>
    /// Copy all elements of a packed array into a native array. Elements are arranged row-by-row.
    /// For example <c> [1,2,3,4] => [1,2 | 3,4]</c>
    /// </summary>
    /// <param name="matrix">The packed array</param>
    /// <param name="rows">The number of rows in the matrix</param>
    /// <param name="columns">The number of columns in the matrix. If 0, this value is calculated from length/rows</param>
    /// <returns></returns>
    public static double[,] FromPackedArray(this double[] matrix, int rows, int columns = 0)
    {
        if (columns==0)
        {
            columns=matrix.Length/rows;
        }
        double[,] result = new double[rows, columns];
        Buffer.BlockCopy(matrix, 0, result, 0, Buffer.ByteLength(result));
        return result;
    }
