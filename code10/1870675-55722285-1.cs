    var invoice = _context.Invoices.OrderBy(x => x.Id)
        .Select(x => new 
        {
           x.Id,
           // ... Fields the view needs to know about
           InvoiceStatuses = x.InvoiceStatuses.OrderBy(s => s.Id)
               .Select(s => new 
               {
                   s.Id,
                   s.StatusText
               })
               .ToList()
        }).FirstOrDefault();
