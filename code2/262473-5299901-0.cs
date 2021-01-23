    ...
    List<Point> points = CreateImage(Color.Red,600,600);
    ...
        private List<Point> CreateImage(Color drawColor, int width, int height)
        {
            // Create new temporary bitmap.
            Bitmap background = new Bitmap(width, height);
            // Create new graphics object.
            Graphics buffer = Graphics.FromImage(background);
            // Draw your circle.
            buffer.DrawEllipse(new Pen(drawColor,1), 300, 300, 100, 200);
            // Set the background of the form to your newly created bitmap, if desired.
            this.BackgroundImage = background;
            // Create a list to hold points, and loop through each pixel.
            List<Point> points = new List<Point>();
            for (int y = 0; y < background.Height; y++)
            {
                for (int x = 0; x < background.Width; x++)
                {
                    // Does the pixel color match the drawing color?
                    // If so, add it to our list of points.
                    Color c = background.GetPixel(x,y);
                    if (c.A == drawColor.A &&
                        c.R == drawColor.R &&
                        c.G == drawColor.G &&
                        c.B == drawColor.B)
                    {
                        points.Add(new Point(x,y));
                    }
                }
            }
            return points;
        }
