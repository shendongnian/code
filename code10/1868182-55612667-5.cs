    using (var con = new SqlConnection(sqlConnectionStringSource))
    {
        ...
        using (var reader = cmd.ExecuteReader())
        {
            var recordStream=ReaderToStream(reader);
            using(var rd=ObjectReader(recordStream))
            using (var sqlBulk = new SqlBulkCopy(sqlConnectionStringDestination))
            {
                ...
                sqlBulk.WriteToServer(rd);
            }
        }
    }
