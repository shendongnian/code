    // your array as jagged array
    int[][] jtest = { 
        new int[] { 404, 414, 424, 434, 444 }, 
        new int[] { 505, 506, 507, 508, 509 }, 
        new int[] { 312, 313, 314, 315, 316 }, 
        new int[] { 822, 823, 824, 825, 826 } 
        };
    
    // definitions for row ranges
    int firstRow = 1; int lastRow = 2;
    // definitions for col ranges
    int firstCol = 2; int lastCol = 3;
    // int array for copying row elements in col range
    int[] dump = new int[lastCol - firstCol + 1];
    
    // do it
    for (var i = firstRow; i <= lastRow; i++)
    {
        Array.Copy(jtest[i], firstCol, dump, 0, dump.Length);
        Console.WriteLine(string.Join(" ", dump));
    }
