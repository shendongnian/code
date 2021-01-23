    Dim LastToolTip As String
    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        Dim NewToolTip = CalculateTooltipText(e.X, e.Y)
        If LastToolTip <> NewToolTip Then
            ToolTip1.SetToolTip(PictureBox1, NewToolTip)
            LastToolTip = NewToolTip
        End If
    End Sub
