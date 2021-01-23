    Private Sub ButtonTotalSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTotalSales.Click
        Dim sales As Decimal = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            sales += CDec(row.Cells("sales").Value)
        Next
        '' etc..
    End Sub
