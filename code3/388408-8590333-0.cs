    Private Sub Button1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Button1.Paint
        Dim bm As New Bitmap(Me.Button1.Width, Me.Button1.Height, PixelFormat.Format32bppRgb)
    
        Button1.DrawToBitmap(bm, New Rectangle(0, 15, bm.Width -5, bm.Height+2))
        Using gr As Graphics = Graphics.FromImage(bm)
            gr.DrawString(DateTime.Now.ToLongTimeString, Me.Font, Brushes.Lime, 0, 0)
        End Using
        Me.PictureBox1.BackgroundImageLayout = ImageLayout.Tile
        Me.PictureBox1.BackgroundImage = bm
    
    End Sub
        Public Class myTextBox
            Inherits System.Windows.Forms.TextBox
        
        
            Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
                MyBase.OnPaint(e)
                e.Graphics.Clear(Color.Yellow)
                e.Graphics.DrawString(DateTime.Now.ToLongTimeString, Me.Font, Brushes.Gray, 0, 0)
            End Sub
        
            Public Sub New()
                SetStyle(ControlStyles.UserPaint, True)
            End Sub
        End Class
 
