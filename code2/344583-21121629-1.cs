    Public Module Utilities
    
        <Extension()>
        Public Sub StretchLastColumn(ByVal dataGridView As DataGridView)
            Dim lastColIndex = dataGridView.Columns.Count - 1
            Dim lastCol = dataGridView.Columns.Item(lastColIndex)
            lastCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End Sub
    
    End Module
