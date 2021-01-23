    private Bitmap RotateBitmap(Bitmap bitmap, float angle)
        {
            int w, h, x, y;
            var dW = (double)bitmap.Width;
            var dH = (double)bitmap.Height;
            double degrees = Math.Abs(angle);
            if (degrees <= 90)
            {
                double radians = 0.0174532925 * degrees;
                double dSin = Math.Sin(radians);
                double dCos = Math.Cos(radians);
                w = (int)(dH * dSin + dW * dCos);
                h = (int)(dW * dSin + dH * dCos);
                x = (w - bitmap.Width) / 2;
                y = (h - bitmap.Height) / 2;
            }
            else
            {
                degrees -= 90;
                double radians = 0.0174532925 * degrees;
                double dSin = Math.Sin(radians);
                double dCos = Math.Cos(radians);
                w = (int)(dW * dSin + dH * dCos);
                h = (int)(dH * dSin + dW * dCos);
                x = (w - bitmap.Width) / 2;
                y = (h - bitmap.Height) / 2;
            }
            var rotateAtX = bitmap.Width / 2f;
            var rotateAtY = bitmap.Height / 2f;
            var bmpRet = new Bitmap(w, h);
            bmpRet.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);
            using (var graphics = Graphics.FromImage(bmpRet))
            {
                graphics.Clear(Color.White);
                graphics.TranslateTransform(rotateAtX + x, rotateAtY + y);
                graphics.RotateTransform(angle);
                graphics.TranslateTransform(-rotateAtX - x, -rotateAtY - y);
                graphics.DrawImage(bitmap, new PointF(0 + x, 0 + y));
            }
            return bmpRet;
        }
