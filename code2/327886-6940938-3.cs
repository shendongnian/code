    [WebMethod()]
    public List<Notification> GetNotifications() {
      var notifications = new List<Notification>();
      using (SqlConnection objSQLConnection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connString"))) {
        using (SqlCommand objSQLCommand = new SqlCommand("select * from table1 where col1 = @user", objSQLConnection)) {
          objSQLCommand.Parameters.Add("@user", SqlDbType.VarChar, 5).Value = sUser;
          objSQLConnection.Open();
          using (SqlDataReader objSQLDataReader = objSQLCommand.ExecuteReader()) {
            while (objSQLDataReader.Read()) {
              notifications.Add(new Notification(objSQLDataReader("id"), objSQLDataReader("text")));
            }
          }
        }
      }
      return notifications;
    }
