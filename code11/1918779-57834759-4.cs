    invoices.GroupBy(x => 1)
        .AsQueryable()
        .Select(i => new AggregatedInvoice
        {
            Net = i.Sum(x => x.Net),
            Gross = i.Sum(x => x.Gross)
        })
