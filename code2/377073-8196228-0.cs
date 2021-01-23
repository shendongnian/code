        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }
        
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description",
                                        typeof(string),
                                        typeof(TranslateableCPNavItem),
                                        null);
