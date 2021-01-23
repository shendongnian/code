    // IVector.cs
    public interface IVector<T>
        where T : IVector<T>
    {
        int Size { get; }
        float this[int index] { get; set; }
    }
    // IMatrix.cs
    public interface IMatrix<T>
        where T : IMatrix<T>
    {
        int Size { get; }
        float this[int row, int column] { get; set; }
    }
    // VectorExtensions.cs
    public T Add<T>(IVector<T> vector, T value)
        where T : struct, IVector<T>
    {
        var output = default(T);
        for (int i = 0; i < output.Size; i++)
            output[i] = vector[i] + value[i];
        return output;
    }
    // MatrixExtensions.cs
    public static T Add<T>(this IMatrix<T> matrix, T value)
        where T : struct, IMatrix<T>
    {
        var output = default(T);
        for (int i = 0; i < output.Size; i++)
            for (int j = 0; j < output.Size; j++)
                output[i, j] = vector[i, j] + value[i, j];
        return output;
    }
