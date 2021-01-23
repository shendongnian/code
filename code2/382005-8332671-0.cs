    public interface IShape
    {
         public void Draw();
    }
    
    public class Circle : IShape
    {
        public void Draw()
        {
          do somethig shape specific
        }
    
    }
    
    List<IShape> shapes
    
    foreach (IShape shape in shapes)
    {
         shape.Draw();
    }
