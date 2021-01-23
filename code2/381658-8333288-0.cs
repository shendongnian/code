    private Image<Bgr, byte> bwareaopen(Image<Bgr, byte> Input_Image, int threshold)
    {
     
        Image<Bgr, byte> bwresults = Input_Image.Copy();
     
        using (MemStorage storage = new MemStorage())
        {
            for (Contour<Point> contours = Input_Image.Convert<Gray, byte>().FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST, storage); contours != null; contours = contours.HNext)
            {
                Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.05, storage);
                if (currentContour.Area < threshold) 
                {
                    for (int i = currentContour.BoundingRectangle.X; i < currentContour.BoundingRectangle.X + currentContour.BoundingRectangle.Width; i++)
                    {
                        for (int j = currentContour.BoundingRectangle.Y; j < currentContour.BoundingRectangle.Y + currentContour.BoundingRectangle.Height; j++)
                        {
                            bwresults.Data[j, i, 0] = 0;
                            bwresults.Data[j, i, 1] = 0;
                            bwresults.Data[j, i, 2] = 0;
                        }
                    }
                }
            }
        }
        return bwresults;
    }
