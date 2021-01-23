    using (SqlBulkCopy sbc = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["SQLDatabase"].ConnectionString, SqlBulkCopyOptions.KeepIdentity))
                {
                    sbc.DestinationTableName = "DestinationTable";
                    sbc.ColumnMappings.Add("foo", "bar");
                    sbc.ColumnMappings.Add("hello", "world");
                    sbc.ColumnMappings.Add("col1", "col2");
                    sbc.WriteToServer(data);
                }
