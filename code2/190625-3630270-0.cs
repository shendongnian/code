    public class Shape
    {
    
    }
    
    public class SomethingThatHasShapes
    {
       public List<Shape> Shapes { get; set; }
       public Boxes
       {
          get { return Shapes.Where(s => s.ShapeType = ShapeType.Box); }
       }  
    
    }
