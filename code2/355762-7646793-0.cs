    using(var ctx = new MyContext()) // Unit of Work
    {
        var userRepository = ctx.Set<User>(); // Creates user repository
        userRepository.Add(newUser);
        ctx.SaveChanges();
    }
