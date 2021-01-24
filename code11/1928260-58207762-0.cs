    public static class AdvancedScrolling
    {
        // Attached property boilerplate code begin...
        public static readonly DependencyProperty EnabledProperty =
            DependencyProperty.RegisterAttached("Enabled", typeof(bool), typeof(AdvancedScrolling), new PropertyMetadata(false, EnabledChanged));
        public static void SetEnabled(UIElement element, bool value) => element.SetValue(EnabledProperty, value);
        public static bool GetEnabled(UIElement element) => (bool)element.GetValue(EnabledProperty);
        // ...Attached property boilerplate code end
        private static void EnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Affects only list views
            if (e.NewValue is true && d is ListView listview)
            {
                // We need the visual tree of the list view, so wait for loading first
                listview.Loaded += ListViewLoaded;
            }
            void ListViewLoaded(object sender, RoutedEventArgs re)
            {
                listview.Loaded -= ListViewLoaded;
                // The default list view (grid view) control template contains
                // a Chrome Decorator with a ScrollViewer as Child.
                // We need that ScrollViewer.
                if ((VisualTreeHelper.GetChild(listview, 0) as Decorator)?.Child is ScrollViewer scrollViewer)
                {
                    // Hooking up the tunneling event
                    listview.PreviewMouseWheel += (s, me) =>
                    {
                        // Always scroll manually
                        scrollViewer.ScrollToVerticalOffset(
                            scrollViewer.VerticalOffset
                            - Math.Sign(me.Delta) * SystemParameters.WheelScrollLines);
                        // Set Handled to true to prevent the ScrollViewer
                        // from processing the same event one more time.
                        me.Handled = true;
                    };
                }
            }
        }
    }
