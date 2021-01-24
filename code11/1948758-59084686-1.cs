    Dim DtTable As DataTable = New DataTable
    
    With DtTable
        .Columns.Add(" Name", GetType(String))
        .Columns.Add("Age" + vbLf + " (kg/hr)", GetType(String))
        .Columns.Add("Subject ", GetType(String))
        .Columns.Add(" Marks")
    End With
    
    For Each row As DataRow In DtTable.Rows
        If DtTable.Rows.Count <> 0 Then
            If DtTable.Rows.IndexOf(row) > 2 Then
                ' filter
            End If
        End If
    Next
