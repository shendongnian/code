    Private Sub dgvLegends_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvLegends.CellPainting
        'Draw custom cell borders.
        'If current column is DisplayName...
        If dgvLegends.Columns("DisplayName").Index = e.ColumnIndex AndAlso e.RowIndex >= 0 Then
                Dim Brush As New SolidBrush(dgvLegends.ColumnHeadersDefaultCellStyle.BackColor)
                e.Graphics.FillRectangle(Brush, e.CellBounds)
                Brush.Dispose()
                e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentBackground)
                ControlPaint.DrawBorder(e.Graphics, e.CellBounds, dgvLegends.GridColor, 1, ButtonBorderStyle.Solid, dgvLegends.GridColor, 1, ButtonBorderStyle.Solid, dgvLegends.GridColor, 1, ButtonBorderStyle.Solid, dgvLegends.GridColor, 1, ButtonBorderStyle.Solid)
            e.Handled = True
        End If
    End Sub
