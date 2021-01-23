        private float _opacity = 0.0f;
        private bool _over = false;
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(imgOne);
            ColorMatrix matrix = new ColorMatrix();
            matrix.Matrix33 = _opacity; //opacity 0 = completely transparent, 1 = completely opaque
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            e.Graphics.DrawImage(imgTwo, new Rectangle(0, 0, imgTwo.Width, imgTwo.Height), 0, 0, imgTwo.Width, imgTwo.Height, GraphicsUnit.Pixel, attributes);
            if(_opacity < 1 && _over)
            {
                _opacity += 0.05f;   //  Play with this!!
                Invalidate();
            }
            if(_opacity > 0 && !_over)
            {
                _opacity -= 0.05f;   //  Play with this!!
                Invalidate();    
            }
        }
