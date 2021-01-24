    Bitmap sourceImage = null;
    RectangleF imageLens = RectangleF.Empty;
    Size lensPixelSize = new Size(100, 100);
    LensType lensType = LensType.Circular;
    bool lensUseRelativeSize = false;
    bool drawLens = false;
    private enum LensType
    {
        Circular,
        Rectangular
    }
    private void pctOriginal_MouseMove(object sender, MouseEventArgs e)
    {
        imageLens.Location = GetLensPosition(e.Location, imageLens);
        imageLens.Size = lensUseRelativeSize 
                       ? GetScaledLensSize(pctOriginal.ClientRectangle, sourceImage.Size, lensPixelSize)
                       : lensPixelSize;
        pctOriginal.Invalidate();
        pctLens.Invalidate();
    }
    private PointF GetLensPosition(PointF centerPosition, RectangleF rect)
    {
        return new PointF(centerPosition.X - (rect.Width / 2), 
                          centerPosition.Y - (rect.Height / 2));
    }
    private SizeF GetScaledLensSize(RectangleF canvas, SizeF imageSize, SizeF lensSize)
    {
        float scaleRatio = GetImageScaledRatio(canvas, imageSize);
        return new SizeF(lensSize.Width * scaleRatio, lensSize.Width * scaleRatio);
    }
    private float GetImageScaledRatio(RectangleF canvas, SizeF imageSize)
    {
        return Math.Max(canvas.Width, canvas.Height) /
               Math.Max(imageSize.Width, imageSize.Height);
    }
    private RectangleF CanvasToImageRect(RectangleF canvas, SizeF imageSize, RectangleF rect)
    {
        float scaleRatio = GetImageScaledRatio(canvas, imageSize);
        return new RectangleF(new PointF(rect.X / scaleRatio, rect.Y / scaleRatio),
                              new SizeF(rect.Width / scaleRatio, rect.Height / scaleRatio));
    }
    private void pctOriginal_Paint(object sender, PaintEventArgs e)
    {
        using (Pen pen = new Pen(Color.Red, 2.0f))
        {
            pen.DashStyle = DashStyle.Dash;
            switch (lensType)
            {
                case LensType.Circular:
                    e.Graphics.DrawEllipse(pen, Rectangle.Round(imageLens));
                    break;
                case LensType.Rectangular:
                    e.Graphics.DrawRectangle(pen, Rectangle.Round(imageLens));
                    break;
            }
        }
    }
    private void pctLens_Paint(object sender, PaintEventArgs e)
    {
        if (!drawLens) return;
        RectangleF section = CanvasToImageRect(pctOriginal.ClientRectangle, sourceImage.Size, imageLens);
        DrawImageSelection(e.Graphics, pctLens.ClientRectangle, section, sourceImage);
    }
    private void DrawImageSelection(Graphics g, RectangleF canvas, RectangleF imageSection, Image image)
    {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.DrawImage(image, canvas, imageSection, GraphicsUnit.Pixel);
        switch (lensType)
        {
            case LensType.Circular:
                using (var path = new GraphicsPath())
                {
                    path.AddEllipse(canvas);
                    g.SetClip(path, CombineMode.Exclude);
                    using (var brush = new SolidBrush(Color.FromArgb(160, Color.Black)))
                    {
                        g.FillRectangle(brush, canvas);
                        g.ResetClip();
                        using (var pen = new Pen(brush, 1f))
                            g.DrawEllipse(pen, canvas);
                    }
                }
                break;
            case LensType.Rectangular:
                // NOP
                break;
        }
    }
    private void chkSizeRelative_CheckedChanged(object sender, EventArgs e) 
        => lensUseRelativeSize = chkSizeRelative.Checked;
    private void radLensType_CheckedChanged(object sender, EventArgs e) 
        => lensType = (LensType)(int.Parse((sender as Control).Tag.ToString()));
    private void pctOriginal_MouseEnter(object sender, EventArgs e) 
        => drawLens = true;
    private void pctOriginal_MouseLeave(object sender, EventArgs e)
    {
        drawLens = false;
        pctLens.Invalidate();
    }
