    // int[,] arr = new int[,] { { 1, 2, 3 }, { 3, 1, 2 }, { 2, 3, 1 } };
    int[,] arr = new int[,] { { 1, 2, 2 }, { 3, 2, 3 }, { 2, 1, 1 } };
    int len = arr.GetLength(0);
    bool unique = true;
    for (int x = 0; x < len; x++)
    {
        for (int r = 0; r < len; r++)
            if (r != x && arr[x, x] == arr[r, x])
            {
                unique = false;
                break;
            }
        for (int c = x + 1; c < len; c++)
            if (c != x && arr[x, x] == arr[x, c])
            {
                unique = false;
                break;
            }
    }
    Console.WriteLine(unique);
