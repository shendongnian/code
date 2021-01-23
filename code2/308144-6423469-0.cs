    Private Sub frmTest_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim rc As Rectangle = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Using br As New Drawing2D.HatchBrush(Drawing2D.HatchStyle.Cross, Color.Silver, Color.Transparent)
            e.Graphics.FillRectangle(br, rc)
        End Using
    End Sub
    
    Private Sub frmTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True : Me.Opacity = 10% : Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Color.White
        Me.TransparencyKey = Color.White
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
    End Sub
