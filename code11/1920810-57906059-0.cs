    public void OnClick(..args..)
    {
        Button.IsEnabled = false;
        await SomeTask();
    
        //must be on UI thread. This code is executed on the context captured by the await above.
        Button.IsEnabled = true;
    }
