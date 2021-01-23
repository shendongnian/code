    public static readonly DependencyProperty CountProperty =
                    DependencyProperty.Register("Count", typeof(int), typeof(YourClass), new UIPropertyMetadata(OnCountChanged));
        
    public int Value
    {
           get { return (int)GetValue(CountProperty); }
           set { SetValue(CountProperty, value); }
    }
        
    private static void OnCountChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
    {
           YourClass cp = obj as YourClass;
           MethodToExecute();
    }
