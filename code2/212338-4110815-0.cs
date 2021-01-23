            Dim cols As New List(Of DataGridViewColumn)
            For i As Int32 = 1 To 2
                Dim lastCol As DataGridViewColumn = Me.DataGridView1.Columns(Me.DataGridView1.Columns.Count - 1)
                cols.Add(lastCol)
                Me.DataGridView1.Columns.RemoveAt(Me.DataGridView1.Columns.Count - 1)
            Next
            'print'
            For Each col As DataGridViewColumn In cols
                Me.DataGridView1.Columns.Add(col)
            Next
