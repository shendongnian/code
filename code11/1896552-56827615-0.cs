    // 1D array
    int[] values = new int[] {
        1, 2, 3,
        4, 5, 6
    };
    // 2D array
    int[,] marr = new int[2,3];
    
    // Copy here
    System.Buffer.BlockCopy((Array)values, 0, (Array)marr, 0, (int)marr.LongLength * sizeof(int));
