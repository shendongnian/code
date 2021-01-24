        'generate a datatable with dummy data
        Dim dt As New DataTable()
        dt.Columns.Add("Plant")
        dt.Columns.Add("SumMe")
        dt.Rows.Add("Rose", 1)
        dt.Rows.Add("Rose", 2)
        dt.Rows.Add("Tulip", 3)
        Dim groups = dt.AsEnumerable() _
                      .GroupBy(Function(r) New With {Key .Plant = CStr(r("Plant"))}) _
                      .Select(Function(grp) New With {Key grp.Key.Plant, .SumOf = grp.Sum(Function(ro) CInt(ro("SumMe")))})
        'for results
        Dim dt2 As New DataTable()
        dt2.Columns.Add("x")
        dt2.Rows.Add("x")
        For Each group In groups
            dt2.Columns.Add(group.Plant)
            dt2.Rows(0)(group.Plant) = group.SumOf
        Next group
