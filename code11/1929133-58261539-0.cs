    try
    {
        Ticket ticket = await QueryExistingTicketAsync();
        // ...
    }
    catch (Exception ex)
    {
        if (ticket != null)
        {
