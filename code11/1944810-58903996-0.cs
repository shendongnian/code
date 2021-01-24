    string sqlQuery = "SELECT * FROM yourTable;";
    
    using (var connection = new SqlConnection(yourConnectionString)
    {
    	var yourQueryFromDBList = connection.Query(sqlQuery).ToList();
    	foreach(var item in yourQueryFromDBList)
        {     
            Console.Writeline(item.toString());
        }
     }
