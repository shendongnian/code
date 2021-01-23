    // Somewhere in the setup...
    CollisionMapper mapper = new CollisionMapper();
    mapper.AddHandler(new ShipVsProjectile(gameOptions));
    mapper.AddHandler(new ShipVsShip(gameOptions));
    
    // Somewhere in your collision handling...
    mapper.Resolve(entityOne, entityTwo);
