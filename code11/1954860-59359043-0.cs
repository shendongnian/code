csharp
public int[,,] Project2DInto3D(int[,] source)
{
    int cols = source.GetLength(0);
    int rows = source.GetLength(1);
    int[,,] ret = new int[1, rows, cols];
    for (int x = 0; x < cols; x++)
    {
        for (int y = 0; y < rows; y++)
        {
            ret[0, x, y] = source[x, y];
        }
    }
    return ret;
}
