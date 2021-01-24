     public static readonly DependencyProperty DoStuffCommandProperty = DependencyProperty.Register(
                "DoStuffCommand", typeof(ICommand), typeof(MainWindow), new PropertyMetadata(default(ICommand)));
    
            public ICommand DoStuffCommand
            {
                get { return (ICommand) GetValue(DoStuffCommandProperty); }
                set { SetValue(DoStuffCommandProperty, value); }
            }
    
