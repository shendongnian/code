    Dim connection As OleDbConnection
    Dim connStr As String = ConfigurationManager.ConnectionStrings("ConnStr").ConnectionString<br><br>
    
    Try
            connection = New OleDbConnection(connStr)
            connection.Open()
            If connection.State = Data.ConnectionState.Open Then
                Dim query As String = "Select * from Members where email='" + txtUser.Text + "' And password='" + txtPass.Text + "'"
                Dim sqlcom As New OleDbCommand(query, connection)
                Dim myreader As OleDbDataReader = sqlcom.ExecuteReader()
                myreader.Read()
                If myreader.HasRows = True Then
                      User found do something
                Else
                    User not found
                End If
                myreader.Close()
            End If
        Catch ex As Exception
        Finally
            connection.Close()
        End Try
