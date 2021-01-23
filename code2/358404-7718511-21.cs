    Dim tbl As New DataTable
    Dim row As DataRow
    Dim rnd As New Random(Now.Millisecond)
    tbl.Columns.Add(New DataColumn("ID", GetType(Int32)))
    tbl.Columns.Add(New DataColumn("Type", GetType(Int32)))
    tbl.Columns.Add(New DataColumn("Value", GetType(Int32)))
    For i As Int32 = 1 To 1000000
        row = tbl.NewRow
        row("ID") = 2 * Rnd.Next(0, 6)
        row("Type") = 100 * Rnd.Next(0, 6)
        row("Value") = 5 * Rnd.Next(0, 11)
        tbl.Rows.Add(row)
    Next
