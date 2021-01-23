      public class RedBlackDataTrigger : DataTrigger
      {
        public RedBlackDataTrigger()
        {
          Value = string.Empty;
          Setters.Add(new Setter(Rectangle.StrokeProperty, new SolidColorBrush(Colors.Black)));
        }
      }
