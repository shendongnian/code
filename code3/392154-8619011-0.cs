    Public Module DataSetExtensions
    <Runtime.CompilerServices.Extension()>
    Public Function [Select](ds As DataSet, table As String, ParamArray campos() As String) As DataTable
        Dim dt As New DataTable
        Dim sourceTable = (From t As DataTable In ds.Tables _
            Where t.TableName = table).SingleOrDefault
        Dim columnas = From c As DataColumn In sourceTable.Columns Where campos.Contains(c.ColumnName)
        columnas.ToList.ForEach(Sub(c) dt.Columns.Add(c.ColumnName))
        For Each row As DataRow In sourceTable.Rows
            Dim newRow As DataRow = dt.NewRow
            For Each col As DataColumn In sourceTable.Columns
                If columnas.Contains(col) Then
                    newRow(col.ColumnName) = row(col)
                End If
            Next
            dt.Rows.Add(newRow)
        Next
        Return dt
    End Function
    <Runtime.CompilerServices.Extension()>
    Public Function [Select](ds As DataSet, table As DataTable, ParamArray campos() As String) As DataTable
        Dim dt As New DataTable
        Dim columnas = From c As DataColumn In table.Columns Where campos.Contains(c.ColumnName)
        columnas.ToList.ForEach(Sub(c) dt.Columns.Add(c.ColumnName))
        For Each row As DataRow In table.Rows
            Dim newRow As DataRow = dt.NewRow
            For Each col As DataColumn In table.Columns
                If columnas.Contains(col) Then
                    newRow(col.ColumnName) = row(col)
                End If
            Next
            dt.Rows.Add(newRow)
        Next
        Return dt
    End Function
