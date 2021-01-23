    using (SqlBulkCopy bulkcopy = new SqlBulkCopy(dc.ConnectionString))
    {
            bulkcopy.BulkCopyTimeout = 150; 
 
            // column mapping defined
            dt.Columns.Cast<DataColumn>().ToList().ForEach(f =>
            {
                SqlBulkCopyColumnMapping bccm = new SqlBulkCopyColumnMapping();
                bccm.DestinationColumn = f.ColumnName;
                bccm.SourceColumn = f.ColumnName;
                bulkcopy.ColumnMappings.Add(bccm);
             });
            // column mapping defined
             bulkcopy.DestinationTableName = outputTable;
             bulkcopy.WriteToServer(dt);
           
    }
