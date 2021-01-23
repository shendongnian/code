    [Test]
    public void Can_Retrieve_DomainEvents()
    {
        var userId = Guid.NewGuid();
        var client = new RedisClient("localhost");
        client.FlushAll();
    
        client.As<DomainEvent>().Lists["urn:domainevents-" + userId].Add(
            new UserPromotedEvent { UserId = userId });
    
        var users = client.As<DomainEvent>().Lists["urn:domainevents-" + userId];
    
        Assert.That(users.Count, Is.EqualTo(1));
    
        var userPromoEvent = (UserPromotedEvent)users[0];
        Assert.That(userPromoEvent.UserId, Is.EqualTo(userId));
    }
    
    
    [Test]
    public void Can_from_Retrieve_DomainEvents_list()
    {
        var client = new RedisClient("localhost");
        var users = client.As<AggregateEvents>();
    
        var userId = Guid.NewGuid();
    
        var eventsForUser = new AggregateEvents
        {
            Id = userId,
            Events = new List<DomainEvent>()
        };
    
        eventsForUser.Events.Add(new UserPromotedEvent { UserId = userId });
    
        users.Store(eventsForUser);
    
        var all = users.GetAll(); 
    }
