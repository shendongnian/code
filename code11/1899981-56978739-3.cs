    static int[,] CreateMatrix(List<int> list)
    {
        int[,] matrix = new int[list.Count, list.Count];
        for (int row = 0; row < list.Count; row++)
        {
            for (int col = 0; col < list.Count; col++)
            {
                if (col == row)
                    matrix[row, col] = list[row];
                else
                    matrix[row, col] = 0;
            }
        }
        return matrix;
    }
