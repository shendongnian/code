    public interface IDrawInstructions
    {
        void Draw(IShapeRenderer renderer);
    }
    
    public abstract class Shape
    {
        public abstract IDrawInstructions GetDrawInstructions();
    }
    
    public class Triangle: Shape
    {
        public override IDrawInstructions GetDrawInstructions()
        {
            return new TriangleDrawInstructions(this);
        }
    
        private class TriangleDrawInstructions: IDrawInstructions
        {
            public Triangle Triangle { get; private set; }
    
            public TriangleDrawInstructions(Triangle triangle)
            {
                Triangle = triangle;
            }
    
            public void Draw(IShapeRenderer renderer)
            {
                // draw 3 lines using information from triangle
            }
        }
    }
    
          var renderer = new HtmlRenderer();
          foreach (var shape in shapes)
          {
            var instructions = shape.GetDrawInstructions();
            instructions.Draw(renderer);
          }
