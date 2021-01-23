    public class CustomListBox : ListBox
        {
    
            public IEnumerable ItemsSource
            {
                get { return (IEnumerable)GetValue(ItemsSourceProperty); }
                set { SetValue(ItemsSourceProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty ItemsSourceProperty =
                DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(CustomListBox), new UIPropertyMetadata(0, ItemsSourceUpdated));
    
            private static void ItemsSourceUpdated(object sender, DependencyPropertyChangedEventArgs e)
            {
                var customListbox = (sender as CustomListBox);
                // Your Code
                customListbox.UpdateItemssSource(e.NewValue as IEnumerable);
            }
    
            protected void UpdateItemssSource(IEnumerable source)
            {
                base.ItemsSource = source;
            }
        }
