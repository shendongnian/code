    Private Function GetCircleCursor(iDiameter As Integer) As Cursor
    Dim oBitmap As Bitmap = New Bitmap(Convert.ToInt32(iDiameter), Convert.ToInt32(iDiameter), System.Drawing.Imaging.PixelFormat.Format32bppArgb)
    
        Using g As System.Drawing.Graphics = Graphics.FromImage(oBitmap)
            g.Clear(Color.Transparent)
    
            g.DrawEllipse(New System.Drawing.Pen(Color.White, 3), New Rectangle(0, 0, iDiameter, iDiameter))
            g.DrawEllipse(New System.Drawing.Pen(Color.Black, 1), New Rectangle(0, 0, iDiameter, iDiameter))
        End Using
    
        Return New Cursor(oBitmap.GetHicon)
    End Function
