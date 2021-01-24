    Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.HorizontalScroll.Visible = False
        Panel1.VerticalScroll.Visible = False
        Panel2.AutoScroll = True
        Panel2.HorizontalScroll.Visible = False
        Panel2.VerticalScroll.Visible = True
    End Sub
    Private Sensitivity As Integer = 20
    Private Sub Panel2_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseWheel
        If Panel2.Bounds.Contains(e.Location) Then
            Dim vScrollPosition As Integer = Panel2.VerticalScroll.Value
            vScrollPosition = e.Location.Y
            Panel2.Invalidate()
        End If
    End Sub
    Private Sub Panel2_MouseEnter(sender As Object, e As EventArgs) Handles Panel2.MouseEnter
        Panel2.Select()
    End Sub
    End Class
