    private static void GetBuildingCount1(int No, int[,] Positions)
    {
        var lstRows = new HashSet<int>();
        var lstCols = new HashSet<int>();           
    
        //Get the unique rows and columns
        for (int i = 0; i < Positions.Length / 2; i++)
        {
            lstRows.Add(Positions[i, 0]);
            lstCols.Add(Positions[i, 1]);
        }
    
        var count = (lstRows.Count + lstCols.Count) * 8;
    
        var output = No-count;
    
        Console.WriteLine(output);
    }
