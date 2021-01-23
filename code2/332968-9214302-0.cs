    Private _counter As Integer = 0
    Public Sub NewMessageIncrementOverlay()
      _counter += 1
      Dim displayVal = If(_counter > 9, "+", _counter.ToString)
      Dim bitm As Bitmap = New Bitmap(40, 40,
                             System.Drawing.Imaging.PixelFormat.Format32bppArgb)
      Dim g As Graphics = Graphics.FromImage(bitm)
      g.FillRectangle(System.Drawing.Brushes.Transparent, 0, 0, 40, 40)
      g.FillPie(System.Drawing.Brushes.Red, 0, 0, 40, 40, 0, 360)
      g.DrawString(displayVal, New Font("Consolas", 30, FontStyle.Bold),
                   System.Drawing.Brushes.White, New PointF(3, -5))
      If TaskbarManager.IsPlatformSupported Then
        Dim icon As Icon = icon.FromHandle(bitm.GetHicon)
        TaskbarManager.Instance.SetOverlayIcon(icon, displayVal)
      End If
    End Sub
