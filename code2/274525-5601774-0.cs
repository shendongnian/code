     Dim totalRow = DataTable1.NewRow
     For Each col As DataColumn In DataTable1.Columns
         totalRow(col.ColumnName) = Double.Parse(DataTable1.Compute("SUM(" & col.ColumnName & ")", Nothing).ToString)
     Next
     DataTable1.Rows.Add(totalRow)
