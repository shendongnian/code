    private void pctLens_Paint(object sender, PaintEventArgs e)
    {
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
