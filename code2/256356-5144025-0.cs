    class SomeCoordinate{
      public int X {get;private set;}
      public int X {get;private set;}
      public SomeCoordinate(int X, int Y){
        this.X = X;
        this.Y = Y;
      }
      public static SomeCoordinate operator + (SomeCoordinate left, SomeCoordinate right) {
        // instaed of changing he class, create a new one
        return new SomeCoordinate(left.X + right.X, left.Y + right.Y);
      }
    }
