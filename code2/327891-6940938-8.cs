    <WebMethod()> _
    Public Function GetNotifications() As List(Of Notification)
      Dim notifications As New List(Of Notification)()
      Using connection = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connString"))
        Using command = New SqlCommand("select * from table1 where col1 = @user", connection)
          command.Parameters.Add("@user", SqlDbType.VarChar, 5).Value = sUser;
          connection.Open()
          Using reader = command.ExecuteReader()
            Dim idIndex As Integer = reader.GetOrdinal("id")
            Dim textIndex As Integer = reader.GetOrdinal("text")
            While reader.Read()
              notifications.Add(New Notification(reader.GetInt32(idIndex), reader.GetString(textIndex)))
            End While
          End Using
        End Using
      End Using
      Return notifications
    End Function
