    int[] a = new int[] { 1, 2, 3, 4, 5, 6 };
    int rows = 2;
    int columns = a.Length / rows;
    int[,] b = new int[columns, rows];
    Buffer.BlockCopy(a, 0, b, 0, sizeof(int) * a.Length);
    // b[0, 0] == 1
    // b[0, 1] == 2
    // b[1, 0] == 3
    // b[1, 1] == 4
    // b[2, 0] == 5
    // b[2, 1] == 6
