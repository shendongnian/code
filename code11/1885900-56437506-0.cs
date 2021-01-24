    private static void Main(string[] args)
    {
        Mat source = new Mat("dog.jpg", ImreadModes.Unchanged);
        PointF center = new PointF(Convert.ToSingle(source.Width) / 2, Convert.ToSingle(source.Height) / 2);
        Mat destination = new Mat(new System.Drawing.Size(source.Width, source.Height), DepthType.Cv8U, 3);
        RotatedRect destRect = new RotatedRect(center, source.Size, 35);
        Rectangle bbox = destRect.MinAreaRect();
        RotateImage(ref source, ref destination, destRect);
        CvInvoke.Imshow("Source", source);
        CvInvoke.Imshow("Destination", destination);
        CvInvoke.WaitKey(0);
    }
    private static void RotateImage(ref Mat src, ref Mat destination, RotatedRect destRect)
    {
        PointF[] destCorners = destRect.GetVertices();
        PointF[] srcCorners = new PointF[] {
                new PointF(0F, src.Height),
                new PointF(0F, 0F),
                new PointF(src.Width, 0F),
                new PointF(src.Width, src.Height)
        };
        using (Mat aft = CvInvoke.GetAffineTransform(srcCorners, destCorners))
        using (Mat warpResult = new Mat(src.Size, src.Depth, src.NumberOfChannels))
        {
            CvInvoke.WarpAffine(src, warpResult, aft, destination.Size);
            warpResult.CopyTo(destination);
        }
    }
