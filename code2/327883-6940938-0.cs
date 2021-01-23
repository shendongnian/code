    <WebMethod()> _
    Public Function GetNotifications() As List(Of Notification)
      Dim notifications As New List(Of Notification)()
      Using objSQLConnection = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connString"))
        Using objSQLCommand = New SqlCommand("select * from table1 where col1 = @user", objSQLConnection)
          objSQLCommand.Parameters.Add("@user", SqlDbType.VarChar, 5).Value = sUser;
          objSQLConnection.Open()
          Using objSQLDataReader = objSQLCommand.ExecuteReader()
            While objSQLDataReader.Read()
              notifications.Add(New Notification(objSQLDataReader("id"), objSQLDataReader("text")))
            End While
          End Using
        End Using
      End Using
      Return notifications
    End Function
