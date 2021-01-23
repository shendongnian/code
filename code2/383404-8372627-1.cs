    public static class Helper
    {
        public static bool GetIsLogsChanged(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsLogsChangedProperty);
        }
        public static void SetIsLogsChanged(DependencyObject obj, bool value)
        {
            obj.SetValue(IsLogsChangedProperty, value);
        }
        public static readonly DependencyProperty IsLogsChangedProperty =
            DependencyProperty.RegisterAttached("IsLogsChanged", typeof(bool), typeof(Helper), new PropertyMetadata(false, IsLogsChangedPropertyChanged));
        private static void IsLogsChangedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scrollViewer = d as ScrollViewer;
            if (scrollViewer != null && !(bool)e.NewValue)
            {
                scrollViewer.ScrollToBottom();
            }
        }
    }
