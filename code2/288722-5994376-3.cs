    public class PasswordValidator : FrameworkElement
     {
      static IDictionary<PasswordBox, Brush> _passwordBoxes = new Dictionary<PasswordBox, Brush>();
    
      public static readonly DependencyProperty Box1Property = DependencyProperty.Register("Box1", typeof(PasswordBox), typeof(PasswordValidator), new PropertyMetadata(Box1Changed));
      public static readonly DependencyProperty Box2Property = DependencyProperty.Register("Box2", typeof(PasswordBox), typeof(PasswordValidator), new PropertyMetadata(Box2Changed));
    
      public PasswordBox Box1
      {
       get { return (PasswordBox)GetValue(Box1Property); }
       set { SetValue(Box1Property, value); }
      }
      public PasswordBox Box2
      {
       get { return (PasswordBox)GetValue(Box2Property); }
       set { SetValue(Box2Property, value); }
      }
    
      private static void Box1Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
      }
      private static void Box2Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
       var pv = (PasswordValidator)d;
       _passwordBoxes[pv.Box2] = pv.Box2.BorderBrush;
       pv.Box2.LostFocus += (obj, evt) =>
       {
        if (pv.Box1.Password != pv.Box2.Password)
        {
         pv.Box2.BorderBrush = new SolidColorBrush(Colors.Red);
        }
        else
        {
         pv.Box2.BorderBrush = _passwordBoxes[pv.Box2];
        }
       };
      }
     }
