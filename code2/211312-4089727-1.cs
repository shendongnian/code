    var queryResults = new List<QueryResult>();
    using(var myReader = myCommand.ExecuteReader())
    {
        while(myReader.Read())
        {
            queryResults.Add(new QueryResult
                { 
                    Name = myReader.GetString(myReader.GetOrdinal("name")), 
                    FinalConc = myReader.GetString(myReader.GetOrdinal("finalconc"))
                });
        }
    }
