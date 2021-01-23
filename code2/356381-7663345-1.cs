    public sealed class Colour
    {
      public int RedComponent { get; private set;}
      public int GreenComponent { get; private set;}
      public int BlueComponent { get; private set;}
    
      public static readonly Colour Red = new Colour(255,0,0);
    
      private Colour(int red, int green, int blue)
      {
        RedComponent = red;
        GreenComponent = green;
        BlueComponent = blue;
      }
    }
