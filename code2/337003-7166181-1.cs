    try
    { 
        //Database access code here
    }
    catch(SqlException sexc)
    {
        if (!ReconnectToDatabase())
        {
            // log error to event log
        }
    }
    private bool ReconnectToDatabase()
    {
       bool isConnected = false;
       for (int i = 0; i < 5; i++)  // 5 is arbitrary, use whatever retry count you want
       {
           if (ConnectToSqlServer())
           {
               break;
           }
           System.Threading.Thread.Sleep(5000);  // 5 seconds is arbitrary
       }
    }
