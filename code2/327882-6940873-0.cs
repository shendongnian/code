    [WebMethod()]
    public List<Notification> GetNotifications()
    {
        // Have a look at the code conventions - variable names should not start
        // with a capital letter...
        List<Notification> Notifications = new List<Notification>();
        SqlConnection objSQLConnection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connString"));
        SqlCommand objSQLCommand = new SqlCommand("select * from table1 where col1 = @user", objSQLConnection);
        objSQLCommand.Parameters.Add("@user", SqlDbType.VarChar, 5).Value = sUser;
        objSQLCommand.Connection.Open();
        SqlDataReader objSQLDataReader = objSQLCommand.ExecuteReader();
        while (objSQLDataReader.Read()) {
            Notifications.Add(new Notification(objSQLDataReader("id"), objSQLDataReader("text")));
        }
        objSQLDataReader.Close();
        objSQLCommand.Connection.Close();
        return Notifications;
    }
