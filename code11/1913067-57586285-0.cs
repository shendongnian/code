    protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
            {
                base.OnElementChanged(e);
    
                if (e.OldElement != null)
                {
    
                    var projection = NativeMap.Projection;
    
                    projection.ToScreenLocation();
                    projection.FromScreenLocation();
                }
    
                if (e.NewElement != null)
                {
                    var formsMap = (CustomMap)e.NewElement;
                    customPins = formsMap.CustomPins;
                    Control.GetMapAsync(this);
                }
            }
