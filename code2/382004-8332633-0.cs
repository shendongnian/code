    public interface IDrawingSurface {
        // All your favorite graphics primitives
    }
    
    public abstract class Shape {
        public abstract void Draw();
    
        protected IDrawingSurface Surface {get;set;}
    
        public Shape(IDrawingSurface surface) {
            Surface = surface;
        }
    }
    
    public class Box {
        public Box(IDrawingSurface surface) : base(surface) {}
        public virtual void Draw(){ Surface.Something();... }
    }
    
    public class Square {
        public Square(IDrawingSurface surface) : base(surface) {}
        public virtual void Draw(){ Surface.Something();... }
    }
    
    public class Circle {
        public Circle(IDrawingSurface surface) : base(surface) {}
        public virtual void Draw(){ Surface.Something();... }
    }
