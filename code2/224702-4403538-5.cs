        private static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }
        public static double GetDistanceBetweenPoints(Point p, Point q)
        {
            var a = p.X - q.X;
            var b = p.Y - q.Y;
            return Math.Sqrt(a * a + b * b);
        }
        private static double CalculateTheta(Point p1, Point p2)
        {
            var deltaX = Math.Abs(p1.Y - p2.Y);
            var deltaY = Math.Abs(p1.X - p2.X);
            var theta = RadianToDegree(Math.Atan(deltaY / deltaX));
            return (90 - theta) * -1;
        }
        public void RotateAndSaveImage(string sourceFile, List<Point> subCoords)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(sourceFile);
            bitmap.EndInit();
            var p1 = subCoords[0];
            var p2 = subCoords[1];
            var p4 = subCoords[3];
            var theta = CalculateTheta(p1, p2);
            var width = GetDistanceBetweenPoints(p1, p2);
            var height = GetDistanceBetweenPoints(p1, p4);
            var transformGroup = new TransformGroup();
            var rotateTransform = new RotateTransform(theta)
            {
                CenterX = p1.X,
                CenterY = p1.Y
            };
            transformGroup.Children.Add(rotateTransform);
            var translateTransform = new TranslateTransform
            {
                X = -p1.X,
                Y = -p1.Y
            };
            transformGroup.Children.Add(translateTransform);
            var vis = new DrawingVisual();
            using (var cont = vis.RenderOpen())
            {
                cont.PushTransform(transformGroup);
                cont.DrawImage(bitmap, new Rect(
                    new Size(bitmap.PixelWidth, bitmap.PixelHeight)));
            }
            var rtb = new RenderTargetBitmap((int)width, (int)height,
                96d, 96d, PixelFormats.Default);
            rtb.Render(vis);
            using (var stream = new FileStream(TargetFile, FileMode.Create))
            {
                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(rtb));
                encoder.Save(stream);
            }
        }
