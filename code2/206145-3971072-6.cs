    public string StatusBarText
        {
            get { return (string)GetValue(StatusBarTextProperty); }
            set { SetValue(StatusBarTextProperty, value); }
        }
        // Using a DependencyProperty as the backing store for StatusBarText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatusBarTextProperty =
            DependencyProperty.Register("StatusBarText", typeof(string), typeof(MyOwnerClass), new UIPropertyMetadata(""));
