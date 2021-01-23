        Dim table As new Table 'Here is your table defined in markup, i declared to show an example
    Dim row1 As new tablerow
    Dim row2 As new tablerow
    Dim cel1 As new TableCell With {.Text="row1 cel 1"}
    Dim cel2 As new TableCell With {.Text="row1 cel 2"}
    Dim cel3 As new TableCell With {.Text="row2 cel 1"}
    Dim cel4 As new TableCell With {.Text="row2 cel 2"}
    Dim cel5 As new TableCell With {.Text="row2 cel 3"}
    Dim cel6 As new TableCell With {.Text="row2 cel 4"}
    cel1.ColumnSpan=2
    cel2.ColumnSpan=2
    row1.Cells.AddRange({cel1,cel2})
    row2.Cells.AddRange({cel3,cel4,cel5,cel6})
    table.Rows.AddRange({row1,row2})
