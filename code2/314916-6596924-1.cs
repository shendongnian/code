    var eventMessage = publishIEvent ? Bus.CreateInstance<IEvent>() : new EventMessage();
    
    eventMessage.EventId = Guid.NewGuid();
    eventMessage.Time = DateTime.Now.Second > 30 ? (DateTime?)DateTime.Now : null;
    eventMessage.Duration = TimeSpan.FromSeconds(99999D);
    
    Bus.Publish(eventMessage);
