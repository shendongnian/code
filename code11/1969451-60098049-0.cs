        public static Mat BitmapToIplImage(Bitmap bitmap)
        {
            Mat tmp, tmp2;
            Rectangle bRect = new Rectangle(new System.Drawing.Point(0, 0), new System.Drawing.Size((int)bitmap.Width, (int)bitmap.Height));
            BitmapData bmData = bitmap.LockBits(bRect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            tmp2 = new Mat(new Size(bitmap.Width, bitmap.Height), MatType.CV_8U);
            
            tmp = new Mat(bitmap.Height, bitmap.Width, MatType.CV_8UC3, bmData.Scan0);
            bitmap.UnlockBits(bmData);
            return tmp;         
        }
        private void crop()
        {
            timer1.Stop();
            Graphics Ga = Graphics.FromImage(bmp);
            //the black image
            Ga.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, bmp.Width, bmp.Height));
            //draw from the last point to first point  
            Ga.DrawLine(new Pen(Color.Red, 3), polygonPoints[polygonPoints.Count - 1], polygonPoints[0]);
            //all of the rgb values are being set 1 inside the polygon 
            SolidBrush Brush = new SolidBrush(Color.FromArgb(1, 1, 1));
          //we have to prepare one mask of Multiplying operation for cropping region
            G.FillClosedCurve(Brush, polygonPoints.ToArray());
            var accc= (BitmapToIplImage(Source).Mul(BitmapToIplImage(bmp))).ToMat();
           
            computecrop();
            croplast = accc.ToBitmap().Clone(rectcrop, Source.PixelFormat);//just show cropped region part of image
            pictureBox2.Image = croplast; // crop region of image
        }
        
