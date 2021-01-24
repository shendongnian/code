    public class DeselectBehavior
    {
        public static bool GetIsEnabled(ListBox listBox)
        {
            return (bool)listBox.GetValue(IsEnabledProperty);
        }
        public static void SetIsEnabled(ListBox listBox, bool value)
        {
            listBox.SetValue(IsEnabledProperty, value);
        }
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached(
            "IsEnabled",
            typeof(bool),
            typeof(DeselectBehavior),
            new UIPropertyMetadata(false, OnChanged));
        private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ListBox listBox = d as ListBox;
            if((bool)e.NewValue)
            {
                listBox.AddHandler(ListBoxItem.SelectedEvent, (RoutedEventHandler)OnListBoxItemSelected, true);
            }
            else
            {
                listBox.RemoveHandler(ListBoxItem.SelectedEvent, (RoutedEventHandler)OnListBoxItemSelected);
            }
        }
        private static async void OnListBoxItemSelected(object sender, RoutedEventArgs e)
        {
            await Task.Delay(2000);
            ListBoxItem listBoxItem = e.OriginalSource as ListBoxItem;
            if (listBoxItem != null)
                listBoxItem.IsSelected = false;
        }
    }
