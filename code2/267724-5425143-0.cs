    [Category("jonblind")]
    public object ContentAreaControl
    {
        get { return GetValue(ContentAreaControlProperty); }
        set { SetValue(ContentAreaControlProperty, value); }
    }
    public static readonly DependencyProperty ContentAreaControlProperty = 
        DependencyProperty.Register("ContentAreaControl", typeof(object), typeof(jonblind),
        new FrameworkPropertyMetadata(null));
