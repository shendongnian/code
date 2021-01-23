        internal static void RegisterFrameworkExtensionEvents()
        {
            EventManager.RegisterClassHandler(typeof(ListBox), ListBox.SelectionChangedEvent, new RoutedEventHandler(ScrollToSelectedItem));
        }
        //avoid "async void" unless used in event handlers (or logical equivalent)
        private static async void ScrollToSelectedItem(object sender, RoutedEventArgs e)
        {
            if (sender is ListBox)
            {
                var lb = sender as ListBox;
                if (lb.SelectedItem != null)
                {
                    await lb.Dispatcher.BeginInvoke((Action)delegate
                    {
                        lb.UpdateLayout();
                        if (lb.SelectedItem != null)
                            lb.ScrollIntoView(lb.SelectedItem);
                    });
                }
            }
        }
