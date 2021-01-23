    public static class Helper
    {
        public static bool GetScrollToBottom(DependencyObject obj)
        {
            return (bool)obj.GetValue(ScrollToBottomProperty);
        }
        public static void SetScrollToBottom(DependencyObject obj, bool value)
        {
            obj.SetValue(ScrollToBottomProperty, value);
        }
        public static readonly DependencyProperty ScrollToBottomProperty =
            DependencyProperty.RegisterAttached("ScrollToBottom", typeof(bool), typeof(Helper), new PropertyMetadata(false, ScrollToBottomPropertyChanged));
        private static void ScrollToBottomPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scrollViewer = d as ScrollViewer;
            if (scrollViewer != null && (bool)e.NewValue)
            {
                scrollViewer.ScrollToBottom();
            }
        }
    }
