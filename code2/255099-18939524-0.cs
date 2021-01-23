    var data = "M5.4,3.806h6.336v43.276h20.738v5.256H5.4V3.806z";
    var geometry = Geometry.Parse(data);
    var pathGeometry = geometry.GetFlattenedPathGeometry();
    foreach (var figure in pathGeometry.Figures)
    {
        // Do something interesting with each path figure.
        foreach (var segment in figure.Segments)
        {
            // Do something interesting with each segment.
        }
    }
