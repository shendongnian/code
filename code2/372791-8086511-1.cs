    Thread t = new Thread(()=>
    {
        try
        {
            // I'm not sure what the correct call is for OpenConnection, but the code below
            // seems appropriate. If it's not right, then do it the right way
            DBConnection.OpenConnection(el.Attribute("database_alias").Value);
        }
        catch(ThreadInterruptedException tie)
        {
            // Eat the exception or do something else (i.e. cleanup or whatever)
        }
    });
    t.IsBackground = true;
    t.Start();
    
    // Handling 50 seconds timeout
    if (!t.Join(50000))
    {
        // Interrupt the exception instead of aborting it (this should get you out of blocking states)
        t.Interrupt();
        
        // Force closing because connection is hanging with "connecting" state
        Program.myConnections[el.Attribute("database_alias").Value].Conn.Close();                                                     
    }
