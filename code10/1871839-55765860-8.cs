    private static void ExposeDotNeighbors(char[,] input)
    {
        if (input == null) return;
        // Make a copy of the input array that we can iterate over
        // so that we don't analyze items that we've already changed
        var copy = (char[,]) input.Clone();
        for (var row = 0; row <= copy.GetUpperBound(0); row++)
        {
            for (var col = 0; col <= copy.GetUpperBound(1); col++)
            {
                if (copy[row, col] == '.')
                {
                    // Update neighbors in original array
                    // Above = [row - 1, col], Below = [row + 1, col],
                    // Left = [row, col - 1], Right = [row, col + 1]
                    // Before updating, make sure we're inside the array bounds
                    if (row > 0) input[row - 1, col] = '.';
                    if (row < input.GetUpperBound(0)) input[row + 1, col] = '.';
                    if (col > 0) input[row, col - 1] = '.';
                    if (col < input.GetUpperBound(1)) input[row, col + 1] = '.';
                }
            }
        }
    }
