    static bool AreTablesEqual(DataTable t1, DataTable t2)
    {
        // If the number of rows is different, no need to compare the data
        if (t1.Rows.Count != t2.Rows.Count)
            return false;
    
        for (int i = 0; i < t1.Rows.Count; i++)
        {
            foreach(DataColumn col in t1.Columns)
            {
                if (!Equals(t1.Rows[i][col.ColumnName], t2.Rows[i][col.ColumnName]))
                    return false;
            }
        }
        return true;
    }
