    Public Function ExecCommand(ByVal sql As String) As SqlDataReader
        Dim dReader As SqlDataReader       // Not assigned yet
        Dim cmd As New SqlCommand()
        cmd.CommandText = sql
        cmd.Connection = sm
        Dim isOpened = OpenConnection()    // Fails to connect
        If isOpened Then                   // Not executed
          dReader = cmd.ExecuteReader()
          CloseConnection()
        End If
        Return dReader                     // Return value unknown
