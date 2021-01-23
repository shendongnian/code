    public enum ColorEnum {
        Black,
        Yellow,
        Blue,
        Green
    
    }
    
    public class Circle {
        public const double PI = System.Math.PI;
        public ColorEnum Color;
    
        public Circle(ColorEnum color,int radius)
        {
            this.radius = radius;
            this.Color = color
        } 
    }
