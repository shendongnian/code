    Friend Module Main
      Public Sub Main()
        Dim oColumns As List(Of DataColumn)
        Dim oValue As Object
        Dim oRows As List(Of DataRow)
        Dim oRow As DataRow
        Using oTable As New DataTable
          oTable.Columns.Add(New DataColumn("Weight", GetType(Integer)))
          oTable.Columns.Add(New DataColumn("IsHeavy", GetType(String)))
          oRow = oTable.NewRow
          oRow(0) = 123
          oRow(1) = "False"
          oTable.Rows.Add(oRow)
          Console.WriteLine(oRow(1))
          oRows = oTable.Select.ToList
          oRows.ForEach(Sub(Row)
                          oColumns = oTable.Columns.Cast(Of DataColumn).ToList
                          oColumns.ForEach(Sub(Column)
                                             If Column.DataType = GetType(String) Then
                                               oValue = oRow(Column.Ordinal)
                                               If Boolean.TryParse(oValue, Nothing) Then
                                                 Row(Column.Ordinal) = CStr(oValue).ToLower
                                               End If
                                             End If
                                           End Sub)
                        End Sub)
          Console.WriteLine(oRow(1))
        End Using
        Console.ReadKey()
      End Sub
    End Module
