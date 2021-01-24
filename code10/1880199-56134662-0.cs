    [TestMethod]
    public void RequestResponseBusTest()
    {
        var harness = new InMemoryTestHarness();
    
        var consumer = new TestConsumer();
        harness.OnConfigureInMemoryBus += c =>
        {
            c.ReceiveEndpoint("testqueue", e =>
                e.Consumer(() => consumer));
        };
    
        var observer = new TestPublishObserver();
        harness.OnConnectObservers += c =>
        {
            c.ConnectPublishObserver(observer);
        };
    
        harness.Start().Wait();
        var bus = harness.Bus;
    
        bus.Publish(new TestRequest() { X = 99 }).Wait();
    
        //add this line
        var receivedMessage = harness.Consumed.Select<TestRequest>().FirstOrDefault();
    
        Assert.AreEqual(1, consumer.ConsumedMessages.Count, "consumed");
        Assert.AreEqual(1, observer.PublishedRequests.Count, "requests");
        Assert.AreEqual(1, observer.PublishedResponses.Count, "responses");
    
    }
