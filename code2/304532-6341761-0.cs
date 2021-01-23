    Private Function GetSheetNames(ByVal path As String)
    Dim lst As New List(Of String)
    'Note: this will not work for Excel 2007 (.xlsx) workbooks.
    If IO.File.Exists(path) AndAlso IO.Path.GetExtension(path) = ".xls" Then
    Dim app As New Excel.Application
    Dim WB As Excel.Workbook
    Try
       WB = app.Workbooks.Open(Filename:=path)
       If WB IsNot Nothing Then
         For Each ws As Excel.Worksheet In WB.Sheets
           lst.Add(ws.Name)
         Next
         WB.Close()
         System.Runtime.InteropServices.Marshal.ReleaseComObject(WB)
         WB = Nothing
       End If
    Catch ex As Exception
       MessageBox.Show(ex.Message)
    Finally
       System.Runtime.InteropServices.Marshal.ReleaseComObject(app)
       app = Nothing
    End Try
     End If
     Return lst
