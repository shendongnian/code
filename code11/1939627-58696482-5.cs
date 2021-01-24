    public class Point
    { 
      static private int LastId;
      int Id { get; }
      public Point()
      {
        Id = LastId++;
      }
    }
    List<Point> meshPoints = new List<Point>();
    var meshPointA = new Point();
    var meshPointB = new Point();
    var meshPointC = new Point();
    meshPoints.Add(meshPointA);
    meshPoints.Add(meshPointB);
    meshPoints.Add(meshPointC);
    var meshPoint = meshPoints.Where(p => p.Id == 2).SingleOrDefault();
