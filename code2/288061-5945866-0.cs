    static void Main(string[] args)
    {
        // Open your image
        string path = "test.png";
        Bitmap image = (Bitmap)Bitmap.FromFile(path);
        // locating objects
        BlobCounter blobCounter = new BlobCounter();
        blobCounter.FilterBlobs = true;
        blobCounter.MinHeight = 5;
        blobCounter.MinWidth = 5;
        blobCounter.ProcessImage(image);
        Blob[] blobs = blobCounter.GetObjectsInformation();
        // check for rectangles
        SimpleShapeChecker shapeChecker = new SimpleShapeChecker();
        foreach (var blob in blobs)
        {
            List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blob);
            List<IntPoint> cornerPoints;
            // use the shape checker to extract the corner points
            if (shapeChecker.IsQuadrilateral(edgePoints, out cornerPoints))
            {
                // only do things if the corners form a rectangle
                if (shapeChecker.CheckPolygonSubType(cornerPoints) == PolygonSubType.Rectangle)
                {
                    // here i use the graphics class to draw an overlay, but you
                    // could also just use the cornerPoints list to calculate your
                    // x, y, width, height values.
                    List<Point> Points = new List<Point>();
                    foreach (var point in cornerPoints)
                    {
                        Points.Add(new Point(point.X, point.Y));
                    }
                        
                    Graphics g = Graphics.FromImage(image);
                    g.DrawPolygon(new Pen(Color.Red, 5.0f), Points.ToArray());
                    image.Save("result.png");
                }
            }
        }
    }
