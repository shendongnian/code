    public abstract class Shape 
    {
      public abstract float Volume { get; }
      public static Shape Box(float side)
      {
        return new Box(side);
      }
      class Box : Shape 
      {
        float side;
        public Box(float side) { this.side = side; }
        public override float Volume { get { return side*side*side; } }
      }
    }
