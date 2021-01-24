    List<Contour> smoothedContours = new List<Contour>();
    for (int i = 0; i < contours.Count; i++)
    {
        List<DataPoint> smoothedPoints = new List<DataPoint>(contours[i].Points);
        for (int j = 0; j < SmoothLevel; j++)
        {
            SmoothContour(smoothedPoints);
        }
        Contour contour = new Contour(smoothedPoints, contours[i].ContourLevel);
        smoothedContours.Add(contour);
    }
    contours = smoothedContours;
