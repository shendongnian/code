    var updateManifest = Task<ShippingManifest>.Run(() =>
        {
            Thread.Sleep(5000);  // prove it's really working!
            // GenerateManifest calls service and returns 'ShippingManifest' object 
            return = GenerateManifest();  
        })
                
        .ContinueWith(manifest =>
        {
            // MVVM property
            this.ShippingManifest = manifest.Result;
            
            // or if you are not using MVVM...
            // txtShippingManifest.Text = manifest.Result.ToString();    
            
            System.Diagnostics.Debug.WriteLine("UI manifest updated - " + DateTime.Now);
    
        }, TaskScheduler.FromCurrentSynchronizationContext());
