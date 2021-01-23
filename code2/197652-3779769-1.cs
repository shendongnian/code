    public class ModelRoutedEventArgs : RoutedEventArgs
    {
      public string ExtraMessage { get; set; }
      public ModelRoutedEventArgs(RoutedEvent routedEvent, string message) : base(routedEvent)
      {
        ExtraMessage = message;
      }
      // anything else you'd like to add can go here
    }
