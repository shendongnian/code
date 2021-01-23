    Protected Overrides Sub OnPrintPage(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
            Dim img As Image = Nothing 'Your image source
            Dim ps As PaperSize = MyBase.PrinterSettings.DefaultPageSettings.PaperSize
            Dim pF As RectangleF = MyBase.PrinterSettings.DefaultPageSettings.PrintableArea
            Dim srcF As New RectangleF(0, 0, pg.ImageSize.Width, pg.ImageSize.Height)
            Dim dstF As New RectangleF(0, 0, pF.Width, pF.Height)
            e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            e.Graphics.DrawImage(img, dstF, srcF, GraphicsUnit.Pixel)
            MyBase.OnPrintPage(e)
    End Sub
