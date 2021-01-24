            var groupedRentals = _context.Rentals.GroupBy(g => g.RentalID)
                .Select(x => new
                {
                    RentalID = x.Key,
                    Quote = x.Max(z => z.Quote)
                }).ToList();
            var filteredGroupedRentals = _context.Rentals.Where(r => groupedRentals.Any(g =>
                g.RentalID == r.RentalID &&
                g.Quote == r.Quote))
                .ToList();
