    List<double> areas = new List<double>();
    foreach(Emgu.CV.Util.VectorOfPoint contour in contours)
    {
        areas.Add(Emgu.CV.CvInvoke.ContourArea(contour));
    } 
    
    VectorOfPoint mass_centers = new VectorOfPoint();
    foreach(Emgu.CV.Util.VectorOfPoint contour in contours)
    {
        Emgu.CV.Structure.MCVMoments mu = Emgu.CV.CvInvoke.Moments(contour); 
        mass_centers.Push(Emgu.CV.Point2D<double>(mu.M10 / mu.M00, mu.M01 / mu.M00));
    } 
