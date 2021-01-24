csharp
public int[,,] Project2DInto3D(int[,] source)
{
    int cols = source.GetLength(0);
    int rows = source.GetLength(1);
    int[,,] ret = new int[1, cols, rows];
    for (int x = 0; x < cols; x++)
    {
        for (int y = 0; y < rows; y++)
        {
            ret[0, x, y] = source[x, y];
        }
    }
    return ret;
}
Full example:
csharp
using System;
public class Test
{
    public static void Main()
    {
        int[,] original = { { 5, 3 }, { 2, 1 }, { 8, 3 } };
        Console.WriteLine("Original:");
        for (int j = 0; j < 3; j++)
        {
            for (int k = 0; k < 2; k++)
            {
                Console.WriteLine($"[{j}, {k}] = {original[j, k]}");
            }
        }
        Console.WriteLine();
        
        var projected = Project2DInto3D(original);
        Console.WriteLine("Projected:");
        for (int i = 0; i < 1; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    Console.WriteLine($"[{i}, {j}, {k}] = {projected[i, j, k]}");
                }
            }
        }
    }
    
    public static int[,,] Project2DInto3D(int[,] source)
    {
        int cols = source.GetLength(0);
        int rows = source.GetLength(1);
        int[,,] ret = new int[1, cols, rows];
        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                ret[0, x, y] = source[x, y];
            }
        }
        return ret;
    }
}
Output:
text
Original:
[0, 0] = 5
[0, 1] = 3
[1, 0] = 2
[1, 1] = 1
[2, 0] = 8
[2, 1] = 3
Projected:
[0, 0, 0] = 5
[0, 0, 1] = 3
[0, 1, 0] = 2
[0, 1, 1] = 1
[0, 2, 0] = 8
[0, 2, 1] = 3
