    public class Rectangle : IShape2D
    {
    
       public double Width {get; set;}
       public double Depth {get; set;}
       ...
    
       public Dictionary<string, double> getDimensions()
       {
           return new Dictionary<string, double>
           {
               { nameof(Width), Width },
               { nameof(Depth), Depth }
           };
       }
    }
    public class Circle : IShape2D
    {
    
       public double Diameter {get; set;}
       ...
    
       public Dictionary<string, double> getDimensions()
       {
           return new Dictionary<string, double>
           {
               { nameof(Diameter), Diameter }
           };
       }
    }
