    Private dt As New DataTable
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        dt.Columns.Add("ColumnA", GetType(Integer))
        dt.Columns.Add("ColumnB", GetType(String))
        dt.Columns.Add("ColumnC", GetType(String))
        dt.Rows.Add(100, "text10", "text25")
        dt.Rows.Add(100, "text15")
        dt.Rows.Add(100, "", "text26")
        dt.Rows.Add(100, "", "text25")
        dt.Rows.Add(100, "text14", "text22")
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For Each row As DataRow In dt.Rows
            Dim colB As String = row(1).ToString
            Dim colC As String = row(2).ToString
            If Not String.IsNullOrEmpty(colB) Then
                row(1) = $"-{colB}-"
            End If
            If Not String.IsNullOrEmpty(colC) Then
                row(2) = $"-{colC}-"
            End If
        Next
        DataGridView1.DataSource = dt
    End Sub
