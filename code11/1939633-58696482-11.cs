    public class Point
    { 
      static private int NextID;
      int ID { get; }
      public Point()
      {
        ID = NextID++;
      }
    }
    List<Point> meshPoints = new List<Point>();
    var meshPointA = new Point();
    var meshPointB = new Point();
    var meshPointC = new Point();
    meshPoints.Add(meshPointA);
    meshPoints.Add(meshPointB);
    meshPoints.Add(meshPointC);
    var meshPoint = meshPoints.Where(p => p.ID == 2).SingleOrDefault();
