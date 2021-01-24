    public UIView CreateCustomView(View customView, CGRect size)
    {
        var renderer = Platform.CreateRenderer(customView);
    
        renderer.NativeView.Frame = size;
    
        renderer.NativeView.AutoresizingMask = UIViewAutoresizing.All;
        renderer.NativeView.ContentMode = UIViewContentMode.ScaleToFill;
    
        renderer.Element.Layout(size.ToRectangle());
    
        var nativeView = renderer.NativeView;
    
        nativeView.SetNeedsLayout();
    
        return nativeView;
    }
