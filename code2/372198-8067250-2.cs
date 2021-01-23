      public class Callbackable : ContentControl
      {
        public static readonly RoutedEvent CommandExecutedEvent = EventManager.RegisterRoutedEvent(
            "CommandExecuted", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Callbackable));
    
        // Provide CLR accessors for the event
        public event RoutedEventHandler CommandExecuted
        {
          add { AddHandler(CommandExecutedEvent, value); }
          remove { RemoveHandler(CommandExecutedEvent, value); }
        }
      }
