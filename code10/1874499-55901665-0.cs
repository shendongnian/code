    var control = Control ?? Container;
    if (control is Xamarin.Forms.Platform.Android.ImageButtonRenderer imageButtonRenderer)
    {
    	var isDisposed = imageButtonRenderer.IsDisposed;
    }
