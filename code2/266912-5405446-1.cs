    interface IPoint<TPoint> where TPoint : IPoint
    {
       Double CalcuateDistance(TPoint point);
    }
    
    public class 2DPoint : IPoint<2DPoint>
    {
       public Double X { get; set; }
       public Double Y { get; set; }
       public Double Z { get; set; }
       public Double CalculateDistance(2DPoint point)
       {
          // Calc
       }
    }
    
    public class 3DPoint : IPoint<3DPoint>
    {
       public Double X { get; set; }
       public Double Y { get; set; }
       public Double CalculateDistance(3DPoint point)
       {
          // Calc
       }
    }
