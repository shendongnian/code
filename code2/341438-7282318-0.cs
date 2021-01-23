     protected override void OnPaint(PaintEventArgs e)
        {
            if (FromImage != null && ToImage != null)
            {
                ColorMatrix matrix1 = new ColorMatrix();
                matrix1.Matrix33 = opacity;
                ImageAttributes attributes1 = new ImageAttributes();
                attributes1.SetColorMatrix(matrix1, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                ColorMatrix matrix2 = new ColorMatrix();
                matrix2.Matrix33 = 1 - opacity;
                ImageAttributes attributes2 = new ImageAttributes();
                attributes2.SetColorMatrix(matrix2, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                e.Graphics.DrawImage(FromImage, new Rectangle(0, 0, this.Width, this.Height), 0, 0, this.Width,
                                     this.Height, GraphicsUnit.Pixel, attributes1);
                e.Graphics.DrawImage(ToImage, new Rectangle(0, 0, this.Width, this.Height), 0, 0, this.Width,
                                     this.Height, GraphicsUnit.Pixel, attributes2);
            }
            base.OnPaint(e);
        }
