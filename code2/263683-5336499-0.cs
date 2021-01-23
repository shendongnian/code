    [Test]
    public void SubscribesToExchange()
    {
      var exchange = MockRepository.GenerateMock<IExchangeService>(); //this is the stub
      var service = StreamingNotificationService(exchange); //this is the object we are testing
      
      service.Subscribe();
      service.AssertWasCalled(x => x.Subscribe(););
    }
