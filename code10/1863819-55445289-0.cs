    var totalList = query
         .GroupBy(i => 1, i => new { i.InvoiceTotal }) // <--
         .Select(g => new
         {
              TotalInvoice = g.Sum(i => i.InvoiceTotal)
         })
         .ToList();
