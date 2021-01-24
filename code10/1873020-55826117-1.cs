    public ICommand YourCommand
    {
        get { return (ICommand)GetValue(YourCommandProperty); }
        set { SetValue(YourCommandProperty, value); }
    }
    
    // Using a DependencyProperty as the backing store for YourCommand.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty YourCommandProperty =
                DependencyProperty.Register("YourCommand", typeof(ICommand), typeof(UserControl1), new PropertyMetadata(null));
