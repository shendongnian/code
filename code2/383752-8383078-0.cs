    DataTable dataTableInGridView = (DataTable)emplist_gv.DataSource;
    using (SqlConnection connection =
                new SqlConnection(connectionString))
    {
        using (SqlBulkCopy bulkCopy =
                        new SqlBulkCopy(connection))
        {
            bulkCopy.DestinationTableName =
                "dbo.BulkCopyDemoMatchingColumns";
            try
            {
                // Write from the source to the destination.
                bulkCopy.WriteToServer(dataTableInGridView);
            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }
    }
