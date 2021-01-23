    public static readonly DependencyProperty MessageTextProperty = 
        DependencyProperty.Register("MessageText", typeof(string), typeof(MyWidowClass), 
        new UIPropertyMetadata(string.Empty));
    
            public string MessageText
            {
                get { return (int)GetValue(MessageTextProperty ); }
                set { SetValue(MessageTextProperty , value); }
            }
