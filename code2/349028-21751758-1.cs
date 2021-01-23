        Sub DropMyDatabase()
        Dim Your_DB_To_Drop_Name As String = "YourDB"
        Dim Your_Connection_String_Here As String = "SERVER=MyServer;Integrated Security=True"
        Dim Conn As SqlConnection = New SqlConnection(Your_Connection_String_Here)
        Dim AlterStr As String = "ALTER DATABASE " & Your_DB_To_Drop_Name & " SET OFFLINE WITH ROLLBACK IMMEDIATE"
        Dim AlterCmd = New SqlCommand(AlterStr, Conn)
        Dim DropStr As String = "DROP DATABASE " & Your_DB_To_Drop_Name
        Dim DropCmd = New SqlCommand(DropStr, Conn)
        Try
            Conn.Open()
            AlterCmd.ExecuteNonQuery()
            DropCmd.ExecuteNonQuery()
            Conn.Close()
        Catch ex As Exception
            If (Conn.State = ConnectionState.Open) Then
                Conn.Close()
            End If
            MsgBox("Failed... Sorry!" & vbCrLf & vbCrLf & ex.Message)
        End Try
    End Sub
