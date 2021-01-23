    public interface IShapeRenderer
    {
        void DrawLine(int x1, int y1, int x2, int y2);
    }
    
    public abstract class Shape
    {
        public abstract void Render(IShapeRenderer renderer);
    }
    
    public class Triangle: Shape
    {
        public override void Render(IShapeRenderer renderer)
        {
            // draw 3 lines
        }
    }
    
    public class Square: Shape
    {
        public override void Render(IShapeRenderer renderer)
        {
            // draw 4 lines
        }
    }
    
    public class HtmlRenderer: IShapeRenderer
     {
        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            // draw html line
        }
     }
