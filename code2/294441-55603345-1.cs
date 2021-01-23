         Public Sub CreateWorkBookPassword(WorkBookPath As String, password As String)
    
            Dim excelApplication As New Application()
            Dim excelWorkbook = excelApplication.Workbooks.Add(WorkBookPath)
    
            Try
                excelApplication.DisplayAlerts = False
                excelWorkbook.SaveAs(WorkBookPath, XlFileFormat.xlOpenXMLWorkbook, password)
    
            Finally
                excelWorkbook.Close()
                excelApplication.Quit()
    
                'Close all excel processes that may be running
                Dim excelProcesses() As Process = Process.GetProcessesByName("EXCEL")
                For Each Process As Process In excelProcesses
                    Process.Kill()
                    Exit For
                Next
            End Try
        End Sub
