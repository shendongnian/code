    Public Sub UpdateFormats
        Set MyPlage = Sheets("Report").Range("E13:E1500")
        For Each Cell In MyPlage
        ....
    End Sub
    Private Sub Workbook_BeforeSave(ByVal SaveAsUI As Boolean, Cancel As Boolean)
      call UpdateFormats
    End Sub
