    Dim workTable As DataTable = New DataTable("Customers")
    Dim workCol As DataColumn = workTable.Columns.Add("ID", Type.GetType("System.Int32"))
    workTable.Columns.Add("Total", Type.GetType("System.Decimal"))
    workTable.Columns.Add("Compra", Type.GetType("System.Decimal"))
    Dim row As DataRow = workTable.NewRow()
    row("id") = 2
    row("total") = 1.5
    row("compra") = 3
    workTable.Rows.Add(row)
    row = workTable.NewRow()
    row("id") = 1
    row("total") = 1.5
    row("compra") = 3.3999999999999999
    workTable.Rows.Add(row)
    row = workTable.NewRow()
    row("id") = 1
    row("total") = 1.5
    row("compra") = 5
    workTable.Rows.Add(row)
    Dim detalles As IEnumerable(Of DataRow) = workTable.AsEnumerable()
    Dim query = From detalle In detalles.AsEnumerable() _
                Group detalle By grupoClave = New With _
                                            { _
                                                Key .C2 = detalle("id"), _
                                                Key .C4 = detalle("total")} Into g = Group _
                                        Select New With _
                                        { _
                                            .Col2 = g(0).Field(Of Integer)("id"), _
                                            .Col3 = g(0).Field(Of Decimal)("total"), _
                                            .Col4 = g.Sum(Function(fact) fact.Field(Of Decimal)("compra")) _
                                        }
    For Each p In query
        Console.WriteLine((p.Col2 & p.Col3 & p.Col4))
    Next
