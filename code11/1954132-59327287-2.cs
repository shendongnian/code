    public async Task OnGetAsync()
    {
        if (UserInput == 0)
        {
            Rental = _context.Rentals().ToListAsync();
        }
        else if (UserInput == 1)
        {
            // Get the group of items with min quote    
            Rental = _context.Rentals()
                .GroupBy(r => r.Quote) // Group items with the same quote (Quote becomes the Key)
                .OrderBy(g => g.Key)   // Order the groups by quote (smallest will be first)
                .FirstOrDefault()      // Choose the first group (those with min quote)
                .ToListAsync();        // Select the items into a list
        }
        else
        {
            // Get the group of items with max quote    
            Rental = _context.Rentals()
                .GroupBy(r => r.Quote) // Group items with the same quote (Quote becomes the Key)
                .OrderBy(g => g.Key)   // Order the groups by quote (smallest will be first)
                .LastOrDefault()       // Choose the last group (those with max quote)
                .ToListAsync();        // Select the items into a list
        }
    }
