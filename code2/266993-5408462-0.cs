    public static class AnimationType
    {
       public static bool GetShrink(DependencyObject obj)
       {
          return (bool)obj.GetValue(ShrinkProperty);
       }
    
       public static void SetShrink(DependencyObject obj, bool value)
       {
          obj.SetValue(ShrinkProperty, value);
       }
    
       public static readonly DependencyProperty ShrinkProperty =
          DependencyProperty.RegisterAttached("Shrink", typeof(bool), typeof(AnchoredBlock), new UIPropertyMetadata(false));
    } 
