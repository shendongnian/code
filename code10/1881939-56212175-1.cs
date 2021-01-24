    public static bool CompareRowContent(DataTable table1, DataTable table2)
    {
        if (table1.Rows.Count != table2.Rows.Count)
        {
            return false;
        }
        for (int i = 0; i < table1.Rows.Count; i++)
        {
            var row1 = table1.Rows[i];
            var row2 = table2.Rows[i];
            var decimals1 = GetDecimals(row1.ItemArray, (decimal)1.5);
            var decimals2 = GetDecimals(row2.ItemArray, (decimal)1.0);
            if (!decimals1.SequenceEqual(decimals2))
            {
                return false;
            }
        }
        
        return true;
    }
