    var dbfPath = "/CONTACTS.DBF";
    var options = new DbfDataReaderOptions
    {
        SkipDeletedRecords = true,
        Encoding = EncodingProvider.UTF8
    };
    using (var dbfDataReader = new DbfDataReader.DbfDataReader(dbfPath, options))
    {
        while (dbfDataReader.Read())
        {
            Console.WriteLine(dbfDataReader["FIRSTNAME"])
            Console.WriteLine(dbfDataReader["LASTNAME"])
        }
    }
