    static void Harun00(string CSVFileName)
    {
        string CSVFilePath = @"E:\trials\SoTrials\answers\6260911\data";
        string CSVConnectionString = 
            "Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" + 
            CSVFilePath +
            ";Extensions=asc,csv,tab,txt;Persist Security Info=False;";
        using (OdbcConnection Connection = new OdbcConnection(CSVConnectionString))
        {
            List<string> CSVHeaders = new List<string>();
            string SelectQuery = string.Format(@"SELECT TOP 1 * FROM [{0}]", CSVFileName);
            OdbcCommand Command = new OdbcCommand(SelectQuery, Connection);
            Connection.Open();
            OdbcDataReader Reader = Command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            int ColumnCount = Reader.FieldCount;
            for (int column = 0; column < ColumnCount; column++)
            {
                CSVHeaders.Add(Reader.GetName(column));
            }
            Console.WriteLine(CSVHeaders[0]);
        }
    }
