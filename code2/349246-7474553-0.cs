    var baseMock = new Mock<AbstractBase>();
    var inpcMock = baseMock.As<INotifyPropertyChanged>();
    
    // ...setup event...
    
    propertyChangedMapper.Subscribe(inpcMock.Object);
    
    // ... assertions ...
