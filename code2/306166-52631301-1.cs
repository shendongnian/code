    public interface IPropertyChangedEventHandler
    {
        void PropertyChangedHandler(object sender, PropertyChangedEventArgs e);
    }
    
    public void WhenSettingNameNotifyPropertyChangedShouldBeTriggered()
    {
        // Arrange
        var sut = new Mock<MyClass>();
        
        var handler = new Mock<IPropertyChangedEventHandler>();
        handler.Setup(o => o.PropertyChangedHandler(sut, new PropertyChangedEventArgs(nameof(MyClass.Name))));
    
        sut.PropertyChanged += handlerMock.Object.PropertyChangedHandler;
    
        // Act
        sut.Name = "Guy Smiley";
    
        // Assert
        handler.Verify();
    }
