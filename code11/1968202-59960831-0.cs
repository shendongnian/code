    using(var context = new AppContext())
    {
        var rentalCode = context.RentalCodes.Where(x => !x.IsAssigned)
            .OrderBy(x => x.Sequence)
            .FirstOrDefault();
        if(rentalCode == null)
            throw new InvalidOperationException("All rental codes are assigned.");
    
        rentalCode.IsAssigned = true;
        context.SaveChanges();  // Fetch our next free code, mark it as assigned, and save changes quickly to minimize concurrency risk.
    
        var theatreGroup = new TheatreGroup
        {
            // fill in details...
            RentalCode = rentalCode.RentalCode;
        }
        context.TheatreGroups.Add(theatreGroup);
        context.SaveChanges();
    }
