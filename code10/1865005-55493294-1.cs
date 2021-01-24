    Private Function LoadFromFile(xlsFile As String, ShName As String) As DataTable
        Dim dt As DataTable = Nothing
        '~~> Get the file data in the datatable
        Try
            '~~> Get data from file
            Using MyConnection As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" &
                                                              xlsFile &
                                                              ";Extended Properties=""Excel 12.0;HDR=No;IMEX=1""")
                MyConnection.Open()
                Dim SheetName As String = ShName & "$"
                Using MyCommand As New OleDb.OleDbDataAdapter("select * from [" & SheetName & "]", MyConnection)
                    dt = New DataTable
                    MyCommand.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dt
    End Function
