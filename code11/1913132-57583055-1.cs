    private static void Main()
    {
        var grid = GetSquareGrid(10);
        var neighbors = GetNeighbors(4, 5, grid);
        Console.Write($"Neighbors of [4, 5] are: ");
        Console.Write(string.Join(",", neighbors.Select(n => $"[{n.X},{n.Y}]")));
        GetKeyFromUser("\n\nDone! Press any key to exit...");
    }
    private static Point[,] GetSquareGrid(int size)
    {
        var result = new Point[size, size];
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                result[row, col] = new Point(row, col);
            }
        }
        return result;
    }
