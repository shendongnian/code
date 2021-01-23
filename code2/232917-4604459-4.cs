    public static bool HasNull(this DataTable table)
    {
        foreach (DataColumn column in table.Columns)
        {
            if (table.Rows.OfType<DataRow>().Any(r => r.IsNull(column)))
                return true;
        }
    
        return false;
    }
