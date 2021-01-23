    private int GetColumnIndexIfExists(OracleDataReader dr, string columnName)
    {
        for (int i = 0; i < dr.FieldCount; i++)
        {
            if (dr.GetName(i).Equals(columnName))
            {
                return i;
            }
        }
        return -1;
    }
