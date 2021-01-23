    public static readonly DependencyProperty TextWrappedProperty = 
                               DependencyProperty.RegisterAttached("TextWrapped",
                                     typeof(string), typeof(ThirdPartyControl),
                                     new PropertyMetadata(false, TextWrappedChanged));
    private static void TextWrappedChanged(DependencyObject obj, 
                                                 DependencyPropertyChangedEventArgs e)
    {
        // here obj will be the third party control so cast to that type
        var thirdParty = obj as ThirdPartyControl;
 
        // and set the value of the non dependency text property
        if (thirdParty != null)
            thirdParty.Text = e.NewValue;
    }
