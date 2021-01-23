    public class ClickableTextBlock : TextBlock
    {
        #region Overrides
        protected override void OnMouseLeftButtonDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (e.ClickCount == 2)
            {
                RaiseEvent(new RoutedEventArgs(DoubleClickEvent, this));
            }
        }
        #endregion
        #region DoubleClick RoutedEvent
        public static readonly RoutedEvent DoubleClickEvent = EventManager.RegisterRoutedEvent("DoubleClick",
            RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ClickableTextBlock));
        public event RoutedEventHandler DoubleClick
        {
            add { AddHandler(DoubleClickEvent, value); }
            remove { RemoveHandler(DoubleClickEvent, value); }
        }
        #endregion
    }
