    Friend Module Main
      Public Sub Main()
        Dim oColumns As List(Of DataColumn)
        Dim oRows As List(Of DataRow)
        Dim oRow As DataRow
        Using oTable As New DataTable
          oTable.Columns.Add(New DataColumn("Weight", GetType(Integer)))
          oTable.Columns.Add(New DataColumn("IsHeavy", GetType(String)))
          oRow = oTable.NewRow
          oRow(0) = 123
          oRow(1) = "False"
          oTable.Rows.Add(oRow)
          oColumns = oTable.Columns.Cast(Of DataColumn).Where(Function(Column) Column.DataType = GetType(String)).ToList
          Console.WriteLine(oRow(1))
          oRows = oTable.Select.ToList
          oRows.ForEach(Sub(Row)
                          oColumns.ForEach(Sub(Column)
                                             If Boolean.TryParse(oRow(Column.Ordinal), Nothing) Then
                                               Row(Column.Ordinal) = CStr(oRow(Column.Ordinal)).ToLower
                                             End If
                                           End Sub)
                        End Sub)
          Console.WriteLine(oRow(1))
        End Using
        Console.ReadKey()
      End Sub
    End Module
