        #region Title (DependenyProperty)
        public String Title
        {
            get { return (String)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(String), typeof(TopicListItem), new PropertyMetadata(null));
        #endregion String (DependenyProperty)
