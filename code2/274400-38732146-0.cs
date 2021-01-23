    using System.Windows;
    using System.Windows.Controls;
    public static class ScrollViewer
    {
        public static readonly RoutedEvent LastPageEvent = EventManager.RegisterRoutedEvent(
            "LastPage",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(ScrollViewer));
        private static readonly RoutedEventArgs EventArgs = new RoutedEventArgs(LastPageEvent);
        static ScrollViewer()
        {
            EventManager.RegisterClassHandler(
                typeof(System.Windows.Controls.ScrollViewer),
                System.Windows.Controls.ScrollViewer.ScrollChangedEvent,
                new ScrollChangedEventHandler(OnScrollChanged));
        }
        public static void AddLastPageHandler(UIElement e, RoutedEventHandler handler)
        {
            e.AddHandler(LastPageEvent, handler);
        }
        public static void RemoveLastPageHandler(UIElement e, RoutedEventHandler handler)
        {
            e.RemoveHandler(LastPageEvent, handler);
        }
        private static void OnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.ViewportHeight == 0 || e.VerticalOffset == 0)
            {
                return;
            }
            var verticalSpaceLeft = e.ExtentHeight - e.VerticalOffset;
            if (verticalSpaceLeft < 2 * e.ViewportHeight)
            {
                var scrollViewer = (System.Windows.Controls.ScrollViewer)sender;
                scrollViewer.RaiseEvent(EventArgs);
            }
        }
    }
