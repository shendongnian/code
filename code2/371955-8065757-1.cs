     Delegate clickedHandler = new MouseButtonEventHandler( RootClicked );
     FrameworkElement root = (FrameworkElement)Application.Current.RootVisual;
     RootedEventHandler unloadHandler = null;
     unloadHandler = (s, args) =>
     {
          root.Unloaded -= unloadHandler;
          root.RemoveHandler(UIElement.MouseLeftButtonDownEvent, clickedHandler);
     };
     root.AddHandler( UIElement.MouseLeftButtonDownEvent, clickedHandler , true );
     root.Unloaded += unloadHandler;
