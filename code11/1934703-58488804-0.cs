    async Task MyBulkCopyMethod(string connectionString,DataTable data)
    {
        using(var bcp=new SqlBulkCopy(connectionString))
        {
            //Set up mappings etc.
            //....
            await bcp.WriteToServerAsync(data);   
        }
    }
