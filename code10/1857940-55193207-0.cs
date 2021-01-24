	Device.BeginInvokeOnMainThread(() =>
	{
        MyMap.Pins.Add(pin1);
        MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Convert.ToDouble(resultLatitude), Convert.ToDouble(resultLongitude))
         , Distance.FromMeters(500)));
	});	
