    Friend Module Main
      Public Sub Main()
        Dim iIndex As Integer
        Dim oValue As Object
        Dim oRow As DataRow
        Using oTable As New DataTable
          oTable.Columns.Add(New DataColumn("Weight", GetType(Integer)))
          oTable.Columns.Add(New DataColumn("IsHeavy", GetType(String)))
          oRow = oTable.NewRow
          oRow(0) = 123
          oRow(1) = "False"
          oTable.Rows.Add(oRow)
          Console.WriteLine(oRow(1))
          oTable.Select.ToList.ForEach(Sub(Row)
                                         For iIndex = 0 To oTable.Columns.Count - 1
                                           oValue = oRow(iIndex)
                                           If TypeOf oValue Is String Then
                                             If Boolean.TryParse(oValue, Nothing) Then
                                               Row(iIndex) = CStr(oValue).ToLower
                                             End If
                                           End If
                                         Next
                                       End Sub)
          Console.WriteLine(oRow(1))
        End Using
        Console.ReadKey()
      End Sub
    End Module
