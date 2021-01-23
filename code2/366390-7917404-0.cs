    string connect = ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString;
    if (!String.IsNullOrEmpty(connect))
    {
        //check to see if the connection string needs to be set at runtime
        if (connect.Contains("{0}"))
            connect = String.Format(connect, HttpContext.Current.Server.MachineName);
    }
    return connect;
