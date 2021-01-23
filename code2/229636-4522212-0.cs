    var pin = new Pushpin
    {
    	...
    	Content = Title1
    };
    
    pin.ManipulationStarted += (s, a) =>
    {
    	// Code for the event here
    	// ... do something with Title1
    };
    QuakeLayer.AddChild(pin, pin.Location);
