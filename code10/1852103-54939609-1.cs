    var currencySummary = _unitOfWork.GetRepository<Currency>()
        .GetQueryable()
        .AsNoTracking()
        .Where(c => c.Abbrv.Equals(abbreviation, StringComparison.InvariantCultureIgnoreCase)
            && c.DeletedAt == null && c.IsEnabled)
        .Select( c => new {
            c.Id,
            c.Abbrv,
            Pairs = c.PartialCurrencyPairs.Select(pc => pc.PairName).ToList() // Get names of pairs, or select another annonymous type for multiple properties you care about...
        }).ToList() // Alternatively, when intending for returning lots of data use Skip/Take for paginating or limiting resulting data.    
        .Select( c => new CurrencySummaryDto
        {
            CurrencyId = c.Id,
            Abbreviation = c.Abbrv,
            Pairs = string.Join(", ", c.Pairs)
        }).SingleOrDefault();
