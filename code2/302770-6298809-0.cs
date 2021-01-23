    static class DataPointExtensions
    {
     public DataPoint Average (this IEnumerable<DataPoint> points)
     {
       int sumX=0, sumY=0, sumZ=0, count=0;
       foreach (var pt in points)
       {
          sumX += pt.X;
          sumY += pt.Y;
          sumZ += pt.Z;
          count++;
       }
       // also calc average time?
       if (count == 0)
         return new DataPoint ();
       return new DataPoint {X=sumX/count,Y=sumY/count,Z=sumZ/count};
     }
    }
