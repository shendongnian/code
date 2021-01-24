    public class AnimaBehavior
    {
      public static readonly DependencyProperty ContentProperty = DependencyProperty.RegisterAttached(
            "Content", typeof(AnimaCollection), typeof(UserControl), new FrameworkPropertyMetadata(new AnimaCollection(), BehaviorPropertyChangedCallback));
    
      public static readonly DependencyProperty ContentProperty = DependencyProperty.RegisterAttached(
            "IsEnabled", typeof(bool), typeof(UserControl), new FrameworkPropertyMetadata(false, InitializeOnAttached));
      public static void SetContent(UIElement element, AnimaCollection value)
      {
        element.SetValue(IsBubbleSourceProperty, value);
      }
      public static bool GetContent(UIElement element)
      {
        return (AnimaCollection) element.GetValue(IsBubbleSourceProperty);
      }
    
      private void InitializeOnAttached(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
        if (d is Button attachingElement)
        {
           // Use or store Button
           // Or subscribe to CollectionChanged
           var contentCollection = AnimaBehavior.GetContent(attachingElement) as AnimaCollection;
        }
      }
    }
