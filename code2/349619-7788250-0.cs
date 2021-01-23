    var messageHub = new TinyMessengerHub();
    // Publishing a message is as simple as calling the "Publish" method.
    messageHub.Publish(new MyMessage());
    
    // We can also publish asyncronously if necessary
    messageHub.PublishAsync(new MyMessage());
    // And we can get a callback when publishing is completed
    messageHub.PublishAsync(new MyMessage(), MyCallback); 
    // MyCallback is executed on completion
