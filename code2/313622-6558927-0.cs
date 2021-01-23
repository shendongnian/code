    class Foo : Form {
      static Bitmap sIcon     { get; private set; }
      static Point  sPosition { get; private set; }
    
      static Foo() {
        sIcon     = /* Load from external source */
        sPosition = new Point( x, y ); //Insert x and y
      }
    
      public Foo()
      : base() {
        Icon     = Foo.sIcon;
        Position = Foo.sPosition;
      } 
    }
