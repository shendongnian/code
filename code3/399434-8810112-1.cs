    public static readonly DependencyProperty ImageIDProperty =
        DependencyProperty.Register("ImageID", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(string.Empty));
        public string ImageID
        {
            get { return (string)GetValue(ImageIDProperty); }
            set { SetValue(ImageIDProperty, value.Trim()); }
        }
