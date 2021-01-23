    public class LazyLoadEventArgs: EventArgs
    {
        public object Data { get; set; }
        public string PropertyName { get; set; }
        public int Key { get; set; }
    }
