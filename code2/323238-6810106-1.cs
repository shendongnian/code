    public static DataTable DTTable(string mysqlQuery, out DataTable DTTableTable)
        {
        DataTable Result = null;
        try
        {
        MySqlDataAdapter DataDTTables = new MySqlDataAdapter(mysqlQuery, Connection);
        DataDTTables.SelectCommand.CommandTimeout = 240000;
        DataTable DataDTTablesDT = new DataTable();
        DataDTTables.Fill(DataDTTablesDT);
        DTTableTable = DataDTTablesDT;
        EventLog.WriteEntry(StaticStringClass.crawlerID, "Returning Sucessful datatable query:  "+mysqlQuery);
        Result =  DataDTTablesDT;
        }
        catch (Exception ex)
        {
        string messageString = "Could not fill database for query:  " + mysqlQuery + " because of error:  " + ex.Message.ToString();
        LoggingClass.GenericLogging(messageString);
        }
    return Result;
    }
