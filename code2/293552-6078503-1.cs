    Db record = new Db();
    
    var mockRepository = new Mock<IRepository>();
    mockRepository.Setup(r => r.GetDbRecord()).Returns(record);
    
    var mockLoggingService = new Mock<ILoggingService>();
    
    var mockNotificationClient = new Mock<INotificationClient>();
    
    new MyClass(
        mockRepository.Object,
        mockLoggingService.Object,
        mockNotificationClient.Object).DoSomething();
    
    // NUnit syntax:
    Assert.That(record["ExpectedUpdatedField"], Is.EqualTo("ExpectedUpdatedValue"));
        
    mockRepository.Verify(r => r.UpdateDbRecord(record), Times.Exactly(1));
        
    mockLoggingService.Verify(ls => ls.LogInformation(It.IsAny<string>()), Times.Exactly(1));
        
    mockNotificationClient.Verify(nc => nc.SendNotification(record), Time.Exactly(1));
