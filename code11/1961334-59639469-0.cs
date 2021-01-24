    using MyContext context = new MyContext();
    IList<Client> clients =
        context.Clients
            .Include(c => c.Address)
            .Where(c => c.LastName == "patel")
            .ToList();
