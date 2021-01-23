      public class RectangleStyle : Style
      {
        public RectangleStyle()
        {
          TargetType = typeof (Rectangle);
          Setters.Add(new Setter(Rectangle.StrokeProperty, new SolidColorBrush(Colors.Red)));
        }
    
        public string ColorTrigger
        {
          set
          {
            Triggers.Add(new RedBlackDataTrigger {Binding = new Binding(value) });
          }
        }
      }
