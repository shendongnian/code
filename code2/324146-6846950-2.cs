    //Confirms "Do" method calls "TraceWriteLine"
    public void Do_Called_CallsTraceWriteLine()
    {
        //Arrange
        var loggerMock = new Mock<IMyLogger>();
        loggerMock.Setup(l => l.TraceWriteLine(It.IsAny<string.());
    
        var target = new MyCode(loggerMock.Object);
    
        //Act
        target.Do();
    
        //Assert
        loggerMock.VerifyAll(); 
    }
