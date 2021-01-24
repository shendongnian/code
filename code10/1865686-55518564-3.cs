    using (SqlBulkCopy bcp = new SqlBulkCopy(sqc))
            {
                bcp.DestinationTableName = strTargetTable;
                bcp.ColumnMappings = classInstance.GetObjectNameColumnMappings();
                bcp.BatchSize = 50000;
                bcp.BulkCopyTimeout = 12000;
                bcp.WriteToServer(sourceData);
            }
