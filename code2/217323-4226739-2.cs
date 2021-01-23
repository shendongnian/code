        public INavigate Navigator
        {
            get { return GetValue(NavigatorProperty) as INavigate; }
            set { SetValue(NavigatorProperty, value); }
        }
        public static readonly DependencyProperty NavigatorProperty =
            DependencyProperty.Register(
                "Navigator",
                typeof(INavigate),
                typeof(TopSearchBar),
                new PropertyMetadata(null));
   
