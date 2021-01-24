    private static void Run(string[] files)
    {
        var sql = $@"
            MERGE TestsResults AS target  
            USING (SELECT @TestId, @DataPointA, @DataPointB, @Duration, @Result) AS source (TestID, DataPointA, DataPointB, Duration, Result)  
            ON (target.TestID = source.TestID)  
            WHEN MATCHED THEN
                UPDATE SET DataPointA = source.DataPointA, DataPointB = source.DataPointB, Duration = source.Duration, Result = source.Result
            WHEN NOT MATCHED THEN  
                INSERT (TestID, DataPointA, DataPointB, Duration, Result)  
                VALUES (source.TestID, source.DataPointA, source.DataPointB, source.Duration, source.Result);";
        // Get database connection
        var dbConnection = GetDbConnection();
        // Create base command from sql
        var cmd = dbConnection.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sql;
        var paramsNames = new[] { "@TestId", "@DataPointA", "@DataPointB", "@Duration", "@Result" };
    
        foreach (var file in files)
        {
            // Using HtmlAgilityPack to load the document
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(file);
            // Getting all TR from document, skipping first with header
            var rowsCollection = doc.DocumentNode.SelectNodes("//tr").Skip(1);
            foreach (var row in rowsCollection)
            {
                // Getting all TDs in current row and converting contents to string[]
                var values = row.SelectNodes("td").Select(el => el.InnerText).ToArray();
    
                // insert or update in database: each row is a new DbParameter set for our DbCommand
                cmd.Parameters.Clear();
                for (int i = 0; i < paramsNames.Length; i++)
                {
                    var param = cmd.CreateParameter();
                    param.ParameterName = paramsNames[i];
                    param.DbType = DbType.String;
                    param.Value = values[i];
                    cmd.Parameters.Add(param);
                }
                // Run the command, will update existing tests and adding new ones
                cmd.ExecuteNonQuery();
            }
        }
    }
