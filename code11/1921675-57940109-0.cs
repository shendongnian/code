        public Bitmap Render()
        {
            var bitmapRender = this.CreateRenderTargetBitmap();
            var drawingContext = this.drawingVisual.RenderOpen();
            drawingContext.DrawVideo(this.MediaPlayer, this.drawingRect);
            drawingContext.Close();
            bitmapRender.Render(this.drawingVisual);
            var result = new Bitmap(this.Width, this.Height, DrawingPixelFormat);
            var bitmapData = result.LockBits(
                this.renderRect, 
                System.Drawing.Imaging.ImageLockMode.WriteOnly, 
                DrawingPixelFormat);
            bitmapRender.CopyPixels(
                Int32Rect.Empty,
                bitmapData.Scan0,
                bitmapData.Stride * bitmapData.Height,
                bitmapData.Stride);
            result.UnlockBits(bitmapData);
            return result;
        }
        RenderTargetBitmap CreateRenderTargetBitmap() => new RenderTargetBitmap(
                this.Width, this.Height,
                this.Dpi, this.Dpi,
                WpfPixelFormat);
