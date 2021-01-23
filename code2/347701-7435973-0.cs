     using (SqlBulkCopy copy = new SqlBulkCopy(
       {   
                    copy.ColumnMappings.Add("dtcolumnname", "sqlcolumnname");
            
            copy.DestinationTableName = "TABLE";
            copy.WriteToServer(table);
        }
