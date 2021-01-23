     Public Sub RemoveDuplicateRows(ByRef rDataTable As DataTable)
        Dim pNewDataTable As DataTable
        Dim pCurrentRowCopy As DataRow
        Dim pColumnList As New List(Of String)
        Dim pColumn As DataColumn
        'Build column list
        For Each pColumn In rDataTable.Columns
            pColumnList.Add(pColumn.ColumnName)
        Next
        'Filter by all columns
        pNewDataTable = rDataTable.DefaultView.ToTable(True, pColumnList.ToArray)
        rDataTable = rDataTable.Clone
        'Import rows into original table structure
        For Each pCurrentRowCopy In pNewDataTable.Rows
            rDataTable.ImportRow(pCurrentRowCopy)
        Next
    End Sub
