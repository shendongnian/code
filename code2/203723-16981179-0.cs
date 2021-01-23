    using(var bcp = new SqlBulkCopy(connection))
    using(var reader = ObjectReader.Create(data, "Id", "Name", "Description"))
    {
        bcp.DestinationTableName = "SomeTable";
        bcp.WriteToServer(reader);
    }
