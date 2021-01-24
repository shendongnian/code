    string sqlQuery = "SELECT * FROM yourTable;";
    string yourConnectionString = "Server=myAddress:myPortNumber;Database=myDataBase;UID=myUsername;PWD=myPassword"
    using (var connection = new DB2Connection(yourConnectionString)
    {
    	var yourQueryFromDBList = connection.Query(sqlQuery).ToList();
    	foreach(var item in yourQueryFromDBList)
        {     
            Console.Writeline(item.toString());
        }
     }
