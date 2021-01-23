    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString))
    {
        bulkCopy.DestinationTableName = "dbo.DepartmentsItems";
        // Write from the source to the destination.
        foreach (DataColumn c in dt.Columns)
        {
            bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
        }
        bulkCopy.WriteToServer(dt);
        return dt.Rows.Count;
    }
