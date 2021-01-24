    public enum Status
    {
         Unknown,
         Connected,
         NoConnection
    }
    
    public static int retries = 0;
    
    public static Status Check_Internet_For_Acceptation()
        {
            if (Connections.InternetConnection("google.com") == false)
            {
                if(retries >=5)
                   return Status.NoConnection;
                else
                   {retries++; return Status.Unknown;}
            }
            else
                return status.Connected;
        }
