            this.DrawToBitmap(img, bounds);
            Point p = new Point(100, 100);
            img = ResizeBitmap(img, 3);
            e.Graphics.DrawImage(img, p);
        }
        private static Bitmap ResizeBitmap(Bitmap source, int factor)
        {
            Bitmap result = new Bitmap(source.Width*factor, source.Height*factor);
            result.SetResolution(source.HorizontalResolution*factor, source.VerticalResolution*factor);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.DrawImage(source, 0, 0, source.Width*factor, source.Height*factor);
            }
            return result;
        }
