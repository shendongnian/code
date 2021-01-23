    public sealed class ChatHeaderTemplateSelector : DataTemplateSelector
    {
      public override DataTemplate SelectTemplate(object item, DependencyObject container)
      {
        var chatItem = item as ChatMessage;
    
        if (chatItem.IsConcatenated)
          return ((FrameworkElement)container).FindResource("CompactHeader") as DataTemplate;
    
        return ((FrameworkElement)container).FindResource("FullHeader") as DataTemplate;
        }
    }
