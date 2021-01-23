    public class ModelClickEventArgs : RoutedEventArgs
    {
        public string MyString { get; set; }
        public ModelClickEventArgs() : base() { }
        public ModelClickEventArgs(RoutedEvent routedEvent) : base(routedEvent) { }
        public ModelClickEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source) { }
    }
