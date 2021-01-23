        public class TextItem
        {
            public string Text { get; set; }
            public Brush Background { get; set; }
            public Brush Foreground { get; set; }
        }
        public class Row : ObservableCollection<TextItem>
        {
        }
