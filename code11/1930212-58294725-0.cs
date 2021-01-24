    public static readonly DependencyProperty BlubbiProperty = DependencyProperty.Register(
        nameof(Blubbi), typeof(object), typeof(MyControl),
        new PropertyMetadata(default(object), (d, e) => ((MyControl)d).OnBlubbiChanged(e.oldValue, e,newValue)));
    private void OnBlubbiChanged(object oldValue, object newValue)
    {
        // Do something here
    }
