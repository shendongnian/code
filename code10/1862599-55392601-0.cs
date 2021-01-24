    // in c-tor:
    listView.ItemsSource = itemsSource.Select((item) => new ItemWrapper()
    {
       BackgroundColor = ((listView.ItemsSource as IList).IndexOf(item) % 2 == 0) ? BackgroundColor.Gray : BackgroundColor.White,
       Item = item
    });
    
    public class ItemWrapper
    {
        public Color BackgroundColor { get; set; }
        public object Item { get; set; }
    }
