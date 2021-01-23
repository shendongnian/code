        public ObservableCollection<Topic> BookmarkedTopics
        {
            get { return GetValue(BookmarkedTopicsProperty) as ObservableCollection<Topic>; }
            set { SetValue(BookmarkedTopicsProperty, value); }
        }
        public static readonly DependencyProperty BookmarkedTopicsProperty =
            DependencyProperty.Register(
                "BookmarkedTopics",
                typeof(ObservableCollection<Topic>),
                typeof(MainPage),
                new PropertyMetadata(null, OnBookmarkedTopicsPropertyChanged));
        private static void OnBookmarkedTopicsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MainPage source = d as MainPage;
            ObservableCollection<Topic> value = e.NewValue as ObservableCollection<Topic>;
            // Code here to handle any work when the value has changed
        }
