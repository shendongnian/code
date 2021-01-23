    float[][] ptsArray ={
                new float[] {1, 0, 0, 0, 0},
                new float[] {0, 1, 0, 0, 0},
                new float[] {0, 0, 1, 0, 0},
                new float[] {0, 0, 0, 0.5f, 0},
                new float[] {0, 0, 0, 0, 1}};
                ColorMatrix clrMatrix = new ColorMatrix(ptsArray);
                ImageAttributes imgAttributes = new ImageAttributes();
                imgAttributes.SetColorMatrix(clrMatrix,
                ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);
                _ImageThumb.Height, imgAttributes);
                e.Graphics.DrawImage(_ImageThumb,new Rectangle(0, 0, _ImageThumb.Width,_ImageThumb.Height),0, 0, _ImageThumb.Width, _ImageThumb.Height,GraphicsUnit.Pixel, imgAttributes);
