    Friend Module Main
      Public Sub Main()
        Dim oCol As DataColumn
        Dim oRow As DataRow
        Using oTable As New DataTable
          oCol = New DataColumn
          oTable.Columns.Add(oCol)
          oRow = oTable.NewRow
          oRow(0) = "FALSE"
          oTable.Rows.Add(oRow)
          Console.WriteLine(oRow(0))
          oTable.Select.ToList.ForEach(Sub(Row) Row(0) = CStr(Row(0)).ToLower)
          Console.WriteLine(oRow(0))
        End Using
        Console.Read()
      End Sub
    End Module
