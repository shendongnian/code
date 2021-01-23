    public class SelectedRowEventArgs : RoutedEventArgs
    {
        public int Value { get; set; }
        public SelectedRowEventArgs(RoutedEvent routedEvent, int value) : base(routedEvent)
        {
            this.Value = value;
        }
    }
