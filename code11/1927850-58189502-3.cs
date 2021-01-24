    // assume I have a string already from the xml document to use.
    
    List<MyPoint> points = null;
    
    if(serializedPoints.TryParse(out points))
    {
        foreach(var point in points)
        {
            point.Z = X * X + Y * Y;
        }
    }
    
    
    var serializedPointsWithZ = points.SerializeToXml();
