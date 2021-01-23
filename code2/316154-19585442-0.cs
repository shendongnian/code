    Public Class DataGridViewNumberedRow
        Inherits DataGridViewRow
        
        Protected Overrides Sub PaintHeader(graphics As System.Drawing.Graphics, clipBounds As System.Drawing.Rectangle, rowBounds As System.Drawing.Rectangle, rowIndex As Integer, rowState As System.Windows.Forms.DataGridViewElementStates, isFirstDisplayedRow As Boolean, isLastVisibleRow As Boolean, paintParts As System.Windows.Forms.DataGridViewPaintParts)
            MyBase.PaintHeader(graphics, clipBounds, rowBounds, rowIndex, rowState, isFirstDisplayedRow, isLastVisibleRow, paintParts)
            graphics.DrawString(rowIndex + 1, SystemFonts.MenuFont, Brushes.Black, rowBounds)
        End Sub
    End Class
