    public class SelectionChangingEventArgs : RoutedEventArgs
    {
        public bool Cancel { get; set; }
    }
    public delegate void 
    SelectionChangingEventHandler(Object sender, SelectionChangingEventArgs e);
