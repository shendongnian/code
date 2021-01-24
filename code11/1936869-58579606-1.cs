    try
    {
        // business logic
        await _context.SaveChangesAsync();
        // Other business logic
    }
    catch (DbUpdateConcurrencyException ex)
    {
        // your logic to handle optimistic concurrency.
    }
