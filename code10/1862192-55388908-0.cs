    //Arrange
    
    //...
    //Act
    // observable is the SUT.
    var unsubscriber = observable.Subscribe(mock.Object);
    // Cause OnCompleted() to be called: I verified that there's one observer in the observers list in observable and that my break point is correctly hit.
    
    await Task.Delay(TimeSpan.FromSeconds(1.5)); //Or some known duration
    //Assert    
    mock.Verify(v => v.OnCompleted(), Times.AtLeastOnce);
    unsubscriber.Dispose(); 
