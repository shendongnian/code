     public class Curve : ICurve 
     {
         public ControlPoint Start { get; set; }
         public ControlPoint End { get; set; }
         IShape.Start 
         {
             get { return Start; }
             set 
             {
                  if (!(value is ControlPoint)) ... some error handling ...; 
                  Start = (ControlPoint)value; 
             }
         }
         IShape.End { ... similarly as IShape.Start ... }
     }
     public class Line : ILine { ... similarly as Curve ... }
