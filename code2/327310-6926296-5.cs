    public class Lomography
    {
        public static Bitmap getImage(Bitmap bmp)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                using (Bitmap CurveLayer = (Bitmap)bmp.Clone())
                {
                    Lomography.SCurve(CurveLayer);
                    g.DrawImage(CurveLayer, new Rectangle(0, 0, bmp.Width, bmp.Height));
                }
            }
            
            using (Graphics g = Graphics.FromImage(bmp))
            {
                using (Bitmap ColorLayer = (Bitmap)bmp.Clone())
                {
                    Lomography.Colorize(ColorLayer, -12, 25, -12, Lomography.ColorArea.Shadows);
                    g.DrawImage(ColorLayer, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel);
                }
            }
            
            using (Graphics g = Graphics.FromImage(bmp))
            {
                using (Bitmap ColorLayer = (Bitmap)bmp.Clone())
                {
                    Lomography.Colorize(ColorLayer, 12, 12, -25, Lomography.ColorArea.Hightlights);
                    g.DrawImage(ColorLayer, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel);
                }
            }
            using (Graphics g = Graphics.FromImage(bmp))
            {
                RectangleF gradient = new RectangleF(-bmp.Width * 0.3f, -bmp.Height * 0.3f, bmp.Width * 1.6f, bmp.Height * 1.6f);
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(gradient);
                using (PathGradientBrush pgb = new PathGradientBrush(gp))
                {
                    pgb.CenterColor = Color.Yellow;
                    pgb.CenterPoint = new Point(bmp.Width / 2, bmp.Height / 2);
                    ColorBlend cb = new ColorBlend(3);
                    cb.Colors[0] = Color.Black;
                    cb.Colors[1] = Color.Transparent;
                    cb.Colors[2] = Color.Transparent;
                    cb.Positions[0] = 0f;
                    cb.Positions[1] = 0.55f;
                    cb.Positions[2] = 1f;
                    pgb.InterpolationColors = cb;
                    g.FillEllipse(pgb, gradient);
                }
            }
            return bmp;
        }
        public enum ColorArea
        {
            Midtones,
            Shadows,
            Hightlights
        }
        public static bool Colorize(Bitmap b, int red, int green, int blue, ColorArea ca)
        {
            if (red < -255 || red > 255) return false;
            if (green < -255 || green > 255) return false;
            if (blue < -255 || blue > 255) return false;
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int bytes = Math.Abs(bmData.Stride) * b.Height;
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;
            byte[] p = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(Scan0, p, 0, bytes);
            int i = 0;
            int nOffset = stride - b.Width * 3;
            int nPixel;
            for (int y = 0; y < b.Height; ++y)
            {
                for (int x = 0; x < b.Width; ++x)
                {
                    int pdif = (p[i + 2] + p[i + 1] + p[i]) / 3;
                    int newred = p[i + 2];
                    int newgreen = p[i + 1];
                    int newblue = p[i];
                    if (ca == ColorArea.Shadows)
                    {
                        float multi = (1 - newred / 255);
                        newred += (int)(red * multi);
                        multi = (1 - newgreen / 255);
                        newgreen += (int)(green * multi);
                        multi = (1 - newblue / 255);
                        newblue += (int)(blue * multi);
                    }
                    if (ca == ColorArea.Hightlights)
                    {
                        float multi = (newred / 255);
                        newred += (int)(red * multi);
                        multi = (newgreen / 255);
                        newgreen += (int)(green * multi);
                        multi = (newblue / 255);
                        newblue += (int)(blue * multi);
                    }
                    if (ca == ColorArea.Midtones)
                    {
                        float multi = 0;
                        if (newred > 127)
                            multi = 127f / newred;
                        else
                            multi = newred / 127f;
                        newred += (int)(red * multi);
                        if (newgreen > 127)
                            multi = 127f / newgreen;
                        else
                            multi = newgreen / 127f;
                        newgreen += (int)(green * multi);
                        if (newblue > 127)
                            multi = 127f / newblue;
                        else
                            multi = newblue / 127f;
                        newblue += (int)(blue * multi);
                    }
                    nPixel = newred;
                    nPixel = Math.Max(nPixel, 0);
                    p[i + 2] = (byte)Math.Min(255, nPixel);
                    nPixel = newgreen;
                    nPixel = Math.Max(nPixel, 0);
                    p[i + 1] = (byte)Math.Min(255, nPixel);
                    nPixel = newblue;
                    nPixel = Math.Max(nPixel, 0);
                    p[i + 0] = (byte)Math.Min(255, nPixel);
                    i += 3;
                }
                i += nOffset;
            }
            System.Runtime.InteropServices.Marshal.Copy(p, 0, Scan0, bytes);
            b.UnlockBits(bmData);
            return true;
        }
        public static bool SCurve(Bitmap b)
        {
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int bytes = Math.Abs(bmData.Stride) * b.Height;
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;
            byte[] p = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(Scan0, p, 0, bytes);
            int i = 0;
            int nOffset = stride - b.Width * 3;
            int nPixel;
            Point[] points = GetCoordinates();
            for (int y = 0; y < b.Height; ++y)
            {
                for (int x = 0; x < b.Width; ++x)
                {
                    int hue = (p[i] == 255) ? 255 : -1;
                    int hue1 = (p[i + 1] == 255) ? 255 : -1;
                    int hue2 = (p[i + 2] == 255) ? 255 : -1;
                    int p2 = p[i + 2];
                    foreach (var point in points)
                    {
                        if (hue2 == -1 && point.X >= p[i + 2])
                            hue2 = point.Y;
                        if (hue1 == -1 && point.X >= p[i + 1])
                            hue1 = point.Y;
                        if (hue == -1 && point.X >= p[i])
                            hue = point.Y;
                        if (hue != -1 && hue1 != -1 && hue2 != -1)
                            break;
                    }
                    nPixel = hue2;
                    nPixel = Math.Max(nPixel, 0);
                    p[i + 2] = (byte)Math.Min(255, nPixel);
                    nPixel = hue1;
                    nPixel = Math.Max(nPixel, 0);
                    p[i + 1] = (byte)Math.Min(255, nPixel);
                    nPixel = hue;
                    nPixel = Math.Max(nPixel, 0);
                    p[i + 0] = (byte)Math.Min(255, nPixel);
                    i += 3;
                }
                i += nOffset;
            }
            System.Runtime.InteropServices.Marshal.Copy(p, 0, Scan0, bytes);
            b.UnlockBits(bmData);
            return true;
        }
        private static Point[] GetCoordinates()
        {
            List<Point> points = new List<Point>();
            int height = 255;
            int width = 255;
            double y0 = height;
            double y1 = height;
            double y2 = height * 0.75d;
            double y3 = height * 0.5d;
            double x0 = 0;
            double x1 = width * 0.25d;
            double x2 = width * 0.35d;
            double x3 = width * 0.5d;
            for (int i = 0; i < 1000; i++)
            {
                double t = i / 1000d;
                double xt = (-x0 + 3 * x1 - 3 * x2 + x3) * (t * t * t) + 3 * (x0 - 2 * x1 + x2) * (t * t) + 3 * (-x0 + x1) * t + x0;
                double yt = (-y0 + 3 * y1 - 3 * y2 + y3) * (t * t * t) + 3 * (y0 - 2 * y1 + y2) * (t * t) + 3 * (-y0 + y1) * t + y0;
                points.Add(new Point((int)xt, 255 - (int)yt));
            }
            y0 = height * 0.5d;
            y1 = height * 0.25d;
            y2 = 0;
            y3 = 0;
            x0 = width * 0.5d;
            x1 = width * 0.65d;
            x2 = width * 0.75d;
            x3 = width;
            for (int i = 0; i < 1000; i++)
            {
                double t = i / 1000d;
                double xt = (-x0 + 3 * x1 - 3 * x2 + x3) * (t * t * t) + 3 * (x0 - 2 * x1 + x2) * (t * t) + 3 * (-x0 + x1) * t + x0;
                double yt = (-y0 + 3 * y1 - 3 * y2 + y3) * (t * t * t) + 3 * (y0 - 2 * y1 + y2) * (t * t) + 3 * (-y0 + y1) * t + y0;
                points.Add(new Point((int)xt, 255 - (int)yt));
            }
            return points.ToArray();
        }
    }
