      public static readonly DependencyProperty NameProperty =
                DependencyProperty.Register(
                    nameof(Name),
                    typeof(string),
                    typeof(MyUserControl1),
                    null);
    
            public string Name
            {
                get => (string)GetValue(NameProperty);
                set => SetValue(NameProperty, value);
            }
    
            public static readonly DependencyProperty DescriptionProperty =
                DependencyProperty.Register(
                    nameof(Description),
                    typeof(string),
                    typeof(MyUserControl1),
                    null);
    
            public string Description
            {
                get => (string)GetValue(DescriptionProperty);
                set => SetValue(DescriptionProperty, value);
            }
