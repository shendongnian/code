    foreach column c in sourcetable
    {
        if c.ColumnName exists in destination_table.columns
        {
              new SqlBulkCopyColumnMapping(c.ColumnName, c.ColumnName)
        }
    }
