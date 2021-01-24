        public String ButtonContent { get; set; } = "click to hi";
        public SolidColorBrush LabelBackground { get; set; }
        public void Action1()
        {
            LabelBackground  = Brushes.Black;
        }
        public void Action2()
        {
            LabelBackground  = Brushes.Blue;
        }
