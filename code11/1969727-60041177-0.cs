    var dbfPath = "/CONTACTS.DBF";
    var options = new DbfDataReaderOptions
    {
        Encoding = EncodingProvider.UTF8
    };
    using (var dbfDataReader = new DbfDataReader(dbfPath, options))
    {
        while (dbfDataReader.Read())
        {
            Console.WriteLine(dbfDataReader["FIRSTNAME"])
            Console.WriteLine(dbfDataReader["LASTNAME"])
        }
    }
