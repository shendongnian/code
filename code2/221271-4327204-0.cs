    public class Angle
    {
    
       private double _angleInDegrees;
    
       public double Degrees
       {
          get 
          {
              return _angleInDegrees;
          }
          set
          {
              _angleInDegrees = value;
          }
       }
    
       public double Radians
       {
          get
          {   
              return _angleInDegrees * PI / 180;
          }
          set
          {
              _angleInDegrees = value * 180 / PI;
          }
       }
    }
