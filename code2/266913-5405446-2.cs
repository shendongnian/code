    interface IPoint<TPoint> where TPoint : IPoint
    {
       Double CalcuateDistance(TPoint point);
    }
    
    public class 2DPoint : IPoint<2DPoint>
    {
       public Double X { get; set; }
       public Double Y { get; set; }
       public Double CalculateDistance(2DPoint point)
       {
          // some maths using this.X/this.Y and point.X/point.Y
       }
    }
    
    public class 3DPoint : IPoint<3DPoint>
    {
       public Double X { get; set; }
       public Double Y { get; set; }
       public Double Z { get; set; }
       public Double CalculateDistance(3DPoint point)
       {
          // some maths using this.X/this.Y/this.Z and point.X/point.Y/point.Z
       }
    }
