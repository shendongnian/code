    var client = new WebClient();
    
    // Always define event handlers, 
    // BEFORE calling any method that could invoke them.
    client.OpenReadCompleted += (s1, e1)
    {
        Logo = new BitmapImage();
        var extendedImage = new ExtendedImage();
        extendedImage.OnLoadingCompleted += (s2, e2)
        {
            // Invoke the dispatcher, so we're sure it's set on the UI thread.
            Dispatcher.BeginInvoke(new Action
            (
                () => Logo.SetSource(extendedImage.ToStream()))
            );
        };
        extendedImage.SetSource(e1.Result);
    };
    
    client.OpenReadAsync(Uri);
