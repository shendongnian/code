    Public Shared Function GetQueryResults(cmdText As String)
        Dim oConn As New SqlConnection
        oConn.ConnectionString = MainW.MyConnection  ' get connection string
        Dim cmd As New SqlCommand(cmdText, oConn)
        Dim ds As New DataSet()
        Dim da As New SqlDataAdapter(cmd)
        Try
            oConn.Open()
            da.Fill(ds)       ' retrive data
            oConn.Close()
        Catch ex As Exception
            Dim errform As New SysErrScreen
            errform.ChybaText.Text = ex.Message & vbCrLf & vbCrLf & cmdText
            errform.ShowDialog()
            oConn.Close()
        End Try
        Return ds
    End Function
