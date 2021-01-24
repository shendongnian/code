    using (var context = new AppDbContext())
    {
        var rentalCode = context.RentalCodes
            .Where(x => x.TheatreGroup == null)
            .OrderBy(x => x.Sequence)
            .FirstOrDefault();
    
        // ...
    }
