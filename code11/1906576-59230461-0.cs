    var conn = RasConnection.GetActiveConnections().Where(c => c.EntryName == "Test1").FirstOrDefault();
    if (conn!=null)
    {
    	conn.HangUp();
    }
