    SqlConnection dataConnection = null;
    if (ConnectionString != "") // if there is something in the config file work with it
    {
        dataConnection = new SqlConnection(ConnectionString);
    }
    else
    {
        dataConnection = new SqlConnection();
    }
    try
    {
        if(dataConnection != null)
            DoWhatYouWant();
    }
