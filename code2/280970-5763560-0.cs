    private static MemoryStream GetImageResized(MemoryStream data, int previewWidth, int previewHeight)
    {
        const int pixelPadding = 6;
        const int bottomSize = 0;
        using (var src = new Bitmap(data))
        {
            // default to width-based resizing...
            int width = previewWidth;
            var height = (int)(previewWidth / (src.Width / (double)src.Height));
            if (src.Width <= previewWidth && src.Height <= previewHeight)
            {
                // no resizing necessary...
                width = src.Width;
                height = src.Height;
            }
            else if (height > previewHeight)
            {
                // aspect is based on the height, not the width...
                width = previewHeight / ((src.Height / src.Width) == 0 ? 1 : (src.Height / src.Width));
                height = previewHeight;
            }
            using (
              var dst = new Bitmap(width + pixelPadding, height + bottomSize + pixelPadding, PixelFormat.Format24bppRgb))
            {
                var rSrcImg = new Rectangle(0,0, src.Width, src.Height);
                var rDstImg = new Rectangle(pixelPadding / 2, pixelPadding/2, dst.Width - pixelPadding, dst.Height - pixelPadding - bottomSize);
                using (Graphics g = Graphics.FromImage(dst))
                {
                    g.Clear(Color.FromArgb(64, 64, 64));
                    g.FillRectangle(Brushes.White, rDstImg);
                    g.CompositingMode = CompositingMode.SourceOver;
                    g.CompositingQuality = CompositingQuality.GammaCorrected;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                    g.DrawImage(src, rDstImg, rSrcImg, GraphicsUnit.Pixel);
                }
                var ms = new MemoryStream();
                // save the bitmap to the stream...
                dst.Save(ms, ImageFormat.Png);
                ms.Position = 0;
                return ms;
            }
        }
    }
