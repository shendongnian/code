    public class AnimaBehavior
    {
      public static readonly DependencyProperty ContentProperty = DependencyProperty.RegisterAttached(
            "Content", typeof(AnimaCollection), typeof(UserControl), new FrameworkPropertyMetadata(new AnimaCollection(), BehaviorPropertyChangedCallback));
    
      public static readonly DependencyProperty ContentProperty = DependencyProperty.RegisterAttached(
            "IsEnabled", typeof(bool), typeof(UserControl), new FrameworkPropertyMetadata(new AnimaCollection(), InitializeOnAttached));
    
      private void InitializeOnAttached(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
        if (d is Button attachingElement)
        {
           // Use or store Button
        }
      }
    }
