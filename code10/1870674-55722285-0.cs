    var invoice = _context.Invoices.OrderBy(x => x.Id)
        .Select(x => new InvoiceViewModel
        {
           Id = x.Id,
           // ... Fields the view needs to know about
           InvoiceStatuses = x.InvoiceStatuses.OrderBy(s => s.Id)
               .Select(s => s.StatusText)
               .ToList()
        }).FirstOrDefault();
