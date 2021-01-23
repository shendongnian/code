    public static readonly DependencyProperty InfoTextProperty = 
        DependencyProperty.Register(
            "InfoText",
            typeof(string),
            typeof(customtextbox)
        );
        public string InfoText
        {
            get { return (string)GetValue(InfoTextProperty);}
            set {SetValue(InfoTextProperty, value); }
        } 
