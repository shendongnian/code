    [TestMethod]
    public void CreateServiceCallsAddTicketComment(new AutoMoqCustomization());
    {
        var fixture = new Fixture().Customize()
        var apiTicketAdapter = fixture.Freeze<Mock<ITicketApiAdapter>>();
        ticketApiAdapter
            .Setup( x => x.AddTicketComment(
                It.IsAny<User>(), 
                It.IsAny<Customer>(), 
                It.IsAny<TicketComment>()))
            .Returns(new SaveResult
            {
                Success = true, 
                Id = Fixture.CreateAnonymous<Guid>().ToString()
            });
        var createTicketRequest = fixture.Freeze<CreateTicketComment>();
        var createService = fixture.CreateAnonymous<CreateService>();
    
        var results = createService.CreateTicketComment(createTicketRequest);
                
        apiTicketAdapter
            .Verify(x => x.AddTicketComment(
                It.IsAny<User>(), 
                It.IsAny<Customer>(), 
                It.IsAny<TicketComment>()), 
            Times.Once());
    
        Assert.IsTrue(results.All(x => x.Success));
        Assert.IsTrue(results.All(x => x.Errors.Count == 0));
                
    }
