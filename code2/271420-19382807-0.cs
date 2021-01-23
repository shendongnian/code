    Public Class TransparentPictureBox
        Private WithEvents refresher As Timer
        Private _image As Image = Nothing
    
        Public Sub New()
    
            ' This call is required by the designer.
            InitializeComponent()
    
            ' Add any initialization after the InitializeComponent() call.
            refresher = New Timer()
            'refresher.Tick += New EventHandler(AddressOf Me.TimerOnTick)
            refresher.Interval = 50
            refresher.Start()
    
        End Sub
    
        Protected Overrides ReadOnly Property CreateParams() As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                cp.ExStyle = cp.ExStyle Or &H20
                Return cp
            End Get
        End Property
    
        Protected Overrides Sub OnMove(ByVal e As EventArgs)
            MyBase.OnMove(e)
            MyBase.RecreateHandle()
        End Sub
    
        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
    
            'Add your custom paint code here
            If _image IsNot Nothing Then
                e.Graphics.DrawImage(_image, CInt(Width / 2) - CInt(_image.Width / 2), CInt(Height / 2) - CInt(_image.Height / 2))
            End If
        End Sub
    
    
        Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
            ' Paint background with underlying graphics from other controls
            MyBase.OnPaintBackground(e)
            Dim g As Graphics = e.Graphics
    
            If Parent IsNot Nothing Then
                ' Take each control in turn
                Dim index As Integer = Parent.Controls.GetChildIndex(Me)
                For i As Integer = Parent.Controls.Count - 1 To index + 1 Step -1
                    Dim c As Control = Parent.Controls(i)
    
                    ' Check it's visible and overlaps this control
                    If c.Bounds.IntersectsWith(Bounds) AndAlso c.Visible Then
                        ' Load appearance of underlying control and redraw it on this background
                        Dim bmp As New Bitmap(c.Width, c.Height, g)
                        c.DrawToBitmap(bmp, c.ClientRectangle)
                        g.TranslateTransform(c.Left - Left, c.Top - Top)
                        g.DrawImageUnscaled(bmp, Point.Empty)
                        g.TranslateTransform(Left - c.Left, Top - c.Top)
                        bmp.Dispose()
                    End If
                Next
            End If
        End Sub
    
        Public Property Image() As Image
            Get
                Return _image
            End Get
            Set(value As Image)
                _image = value
                MyBase.RecreateHandle()
            End Set
        End Property
    
        Private Sub refresher_Tick(sender As Object, e As System.EventArgs) Handles refresher.Tick
            MyBase.RecreateHandle()
            refresher.Stop()
        End Sub
    End Class
