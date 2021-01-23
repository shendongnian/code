    class MyBaseUserControl : UserControl
    {
        public static readonly RoutedEvent CloseEvent = EventManager.RegisterRoutedEvent(
        "CloseClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Main));
        public event RoutedEventHandler CloseClick
        {
            add { AddHandler(CloseEvent, value); }
            remove { RemoveHandler(CloseEvent, value); }
        }
    }
    MyBaseUserControl content;
    if (value == "main")
    {
        content = new Main();
        content.CloseClick += new RoutedEventHandler(closeClick);
    } else {
        ...
        ...
    }
    MasterPage.addContent(content);
