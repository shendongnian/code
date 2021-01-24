    protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
    
            if (e.OldElement != null)
            {
    
            }
    
            if (e.NewElement != null)
            {
    
                MessagingCenter.Subscribe<CustomMap>(this, "Hi", (sender) =>
                {
                    // Do something whenever the "Hi" message is received
                    Console.WriteLine("hi");
                });
    
                ((CustomMap)e.NewElement).CallToNativeMethod += (sender, arg) =>
                {
                    Console.WriteLine("native method");
                };
            }
        }
