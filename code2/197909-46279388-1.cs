    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnectionStringKic))
    {
        bulkCopy.DestinationTableName = "dbo.DepartmentsItems";
        // Write from the source to the destination.
        foreach (DataColumn c in dt.Columns)
        {
            bulkCopy.ColumnMappings.Add(
                new SqlBulkCopyColumnMapping(c.ColumnName,c.ColumnName));
            }
            bulkCopy.WriteToServer(dt);
            return dt.Rows.Count;
        }
