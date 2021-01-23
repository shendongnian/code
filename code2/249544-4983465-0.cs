        public ObservableCollection<string> Headers
        {
            get { return (ObservableCollection<string>)GetValue(HeadersProperty); }
            set { SetValue(HeadersProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Headers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeadersProperty =
            DependencyProperty.Register("Headers", typeof(ObservableCollection<string>), typeof(Pivot), new UIPropertyMetadata(null));
