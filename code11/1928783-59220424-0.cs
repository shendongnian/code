    public abstract class Shape
    {
    }
    
    [JsonDiscriminator(nameof(Box))]
    public class Box : Shape
    {
        public float Width { get; set; }
    
        public float Height { get; set; }
    
        public override string ToString()
        {
            return $"Box: Width={Width}, Height={Height}";
        }
    }
    
    [JsonDiscriminator("Circle")]
    public class Circle : Shape
    {
        public float Radius { get; set; }
    
        public override string ToString()
        {
            return $"Circle: Radius={Radius}";
        }
    }
