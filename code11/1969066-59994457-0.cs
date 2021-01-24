    var location = Db.OrderLocation.AsTracking()
        .Select(ol => new OrderLocationEntity
        {
            Id = ol.Id,
            Address = ol.Address,
            City = ol.City,
            Created = ol.Created,
            OrderId = ol.OrderId,
            Zip = ol.Zip,
            Location = ol // entity instance passed to the projected object
        })
        .First();
    location.Location.Address = "New Address"; 
    Db.ChangeTracker.Entries<OrderLocationEntity>().ToList(); //after change - 1
