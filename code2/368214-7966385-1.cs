    class MyRect
    {
      public Shape Rectangle;
      public bool FadingIn;
      
      public double Opacity
      {
        get { return Rectangle.Opacity; }
        set { Rectangle.Opacity = value }
      }
      
      //... etc.
    }
