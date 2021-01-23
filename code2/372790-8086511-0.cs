    System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(DBConnection.OpenConnection));
    t.Start(el.Attribute("database_alias").Value);
    
    // Handling 50 seconds timeout
    if (!t.Join(50000))
    {
        t.Abort();
        // Force closing because connection is hanging with "connecting" state
        Program.myConnections[el.Attribute("database_alias").Value].Conn.Close();                                                     
    }
