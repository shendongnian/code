    using(var ctx = new MyContext()) // Unit of Work
    {
        var userRepository = ctx.Set<User>(); // Creates user repository
        var logRepository = ctx.Set<Log>(); // Creates log repository
        userRepository.Add(newUser); // Adds a "pending" item to the userRepository
        logRepositor.Add(logMsg); // Adds a "pending" item to the logRepository
        
        ctx.SaveChanges(); // Adds the "pending" items all at once.
    }
