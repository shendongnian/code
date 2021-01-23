    Private Function GetTextDataSource(ByVal Filename As String, ByVal bIsPreview As Boolean, ByVal bIsCommaSeperated As Boolean) As DataView
    
            Dim sConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath("/Folder/Path/") & ";"
            If chkUploadFileColumnsFirstRow.Checked Then
                sConnectionString &= "Extended Properties='text;HDR=Yes;FMT=" & IIf(bIsCommaSeperated, "CSVDelimited", "TabDelimited") & ";IMEX=1'"
            Else
                sConnectionString &= "Extended Properties='text;FMT=" & IIf(bIsCommaSeperated, "CSVDelimited", "TabDelimited") & ";IMEX=1'"
            End If
    
            Dim objConnection As New OleDbConnection(sConnectionString)
    
            Dim dv As DataView
            Try
                dv = GetOleDbDataView("SELECT " & IIf(bIsPreview, "TOP 1 ", "") & " * FROM [" & Replace(Filename, ";", "") & "]", objConnection)
            Catch ex As OleDbException
                Logger.Error(ex.Message)
                AddError("Error selecting data from uploaded file, please ensure your file matches the correct specification and try again.")
                Return Nothing
            End Try
            Return dv
        End Function
    
        Private Function GetOleDbDataView(ByVal SelectCommand As String, ByVal objConn As OleDbConnection) As DataView
            ' Create new OleDbCommand to return data from worksheet.
            Dim objCmdSelect As New OleDbCommand(SelectCommand, objConn)
    
            ' Create new OleDbDataAdapter that is used to build a DataSet 
            ' based on the preceding SQL SELECT statement.
            Dim objAdapter1 As New OleDbDataAdapter()
    
            ' Pass the Select command to the adapter.
            objAdapter1.SelectCommand = objCmdSelect
    
            ' Create new DataSet to hold information from the worksheet.
            Dim objDataset1 As New DataSet()
    
            ' Fill the DataSet witht he information from the worksheet.
            objAdapter1.Fill(objDataset1, "ExcelReturnData")
    
            Return objDataset1.Tables(0).DefaultView
        End Function
