    public static void InsertIntoMembers(DataTable dataTable)
    {           
        using (var connection = new SqlConnection(@"data source=;persist security info=True;user id=;password=;initial catalog=;MultipleActiveResultSets=True;App=EntityFramework"))
        {
            SqlTransaction transaction = null;
            connection.Open();
            try
            {
                transaction = connection.BeginTransaction();
                using (var sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock, transaction))
                {
                    sqlBulkCopy.DestinationTableName = "Members";
                    sqlBulkCopy.ColumnMappings.Add("Firstname", "Firstname");
                    sqlBulkCopy.ColumnMappings.Add("Lastname", "Lastname");
                    sqlBulkCopy.ColumnMappings.Add("DOB", "DOB");
                    sqlBulkCopy.ColumnMappings.Add("Gender", "Gender");
                    sqlBulkCopy.ColumnMappings.Add("Email", "Email");
                    sqlBulkCopy.ColumnMappings.Add("Address1", "Address1");
                    sqlBulkCopy.ColumnMappings.Add("Address2", "Address2");
                    sqlBulkCopy.ColumnMappings.Add("Address3", "Address3");
                    sqlBulkCopy.ColumnMappings.Add("Address4", "Address4");
                    sqlBulkCopy.ColumnMappings.Add("Postcode", "Postcode");
                    sqlBulkCopy.ColumnMappings.Add("MobileNumber", "MobileNumber");
                    sqlBulkCopy.ColumnMappings.Add("TelephoneNumber", "TelephoneNumber");
                    sqlBulkCopy.ColumnMappings.Add("Deleted", "Deleted");
                    
                    sqlBulkCopy.WriteToServer(dataTable);
                }
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            
        }
    }
