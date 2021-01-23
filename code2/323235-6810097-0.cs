    public static DataTable DTTable(string mysqlQuery, out DataTable DTTableTable)
    {
    	DataTable result;
        try
        {
            MySqlDataAdapter DataDTTables = new MySqlDataAdapter(mysqlQuery, Connection);
            DataDTTables.SelectCommand.CommandTimeout = 240000;
            DataTable DataDTTablesDT = new DataTable();
            DataDTTables.Fill(DataDTTablesDT);
            DTTableTable = DataDTTablesDT;
            EventLog.WriteEntry(StaticStringClass.crawlerID, "Returning Sucessful datatable query:  "+mysqlQuery);
            result = DTTableTable;
        }
        catch (Exception ex)
        {
            string messageString = "Could not fill database for query:  " + mysqlQuery + " because of error:  " + ex.Message.ToString();
            LoggingClass.GenericLogging(messageString);
            result = null;
        }
        return result; //<--- executes even if an exception is thrown
    }
