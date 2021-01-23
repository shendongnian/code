    public static StatusDisplaySurrogates
    {
        public static string GetMessage(StatusDisplay element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            return element.GetValue(MessageProperty) as string;
        }
        public static void SetMessage(StatusDisplay element, string value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            element.SetValue(MessageProperty, value);
        }
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.RegisterAttached(
                "Message",
                typeof(string),
                typeof(StatusDisplay),
                new PropertyMetadata(null, OnMessagePropertyChanged));
        private static void OnMessagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            StatusDisplay source = d as StatusDisplay;
            source.Message = e.NewValue as String;
        }
    }
