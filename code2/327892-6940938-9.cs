    [WebMethod()]
    public List<Notification> GetNotifications() {
      var notifications = new List<Notification>();
      using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connString"])) {
        using (SqlCommand command = new SqlCommand("select * from table1 where col1 = @user", connection)) {
          command.Parameters.Add("@user", SqlDbType.VarChar, 5).Value = sUser;
          connection.Open();
          using (SqlDataReader reader = command.ExecuteReader()) {
            int idIndex = reader.GetOrdinal("id")
            int textIndex = reader.GetOrdinal("text")
            while (reader.Read()) {
              notifications.Add(new Notification(reader.GetInt32(idIndex), reader.GetString(textIndex)));
            }
          }
        }
      }
      return notifications;
    }
