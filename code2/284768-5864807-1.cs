    public static readonly DependencyProperty TextWrappedProperty = 
                               DependencyProperty.RegisterAttached("TextWrapped",
                                     typeof(string), typeof(ThirdPartyControl),
                                     new PropertyMetadata(false, TextWrappedChanged));
    public static void SetTextWrapped(DependencyObject obj, string wrapped)
    {
        obj.SetValue(TextWrappedProperty, wrapped);
    }
    public static string GetTextWrapped(DependencyObject obj)
    {
        return (string)obj.GetValue(TextWrappedProperty);
    }
    private static void TextWrappedChanged(DependencyObject obj, 
                                                 DependencyPropertyChangedEventArgs e)
    {
        // here obj will be the third party control so cast to that type
        var thirdParty = obj as ThirdPartyControl;
 
        // and set the value of the non dependency text property
        if (thirdParty != null)
            thirdParty.Text = e.NewValue;
    }
