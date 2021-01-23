    private static List<DataTable> SplitDataTable(DataTable dt, int size)
    {
        List<DataTable> split = new List<DataTable>();
        DataTable current = dt.Clone();
        
        int iterator1 = 0;
        foreach (DataRow dr in dt.Rows)
        {
            if (current.Rows.Count < size)
            {
                current.Rows.Add(dr.ItemArray);
               
            }
            if (current.Rows.Count == size)
            {
                iterator1= iterator1+size;
                split.Add(current);
                current = dt.Clone();
            }
        }
        if (iterator1 < dt.Rows.Count) { split.Add(current); }
        return split;
    }
