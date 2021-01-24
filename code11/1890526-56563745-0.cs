    var currencyLookUp = currencies.Select(x => new LookUpViewModel()
    {
        Id = x.CURRENCY_ID, 
        Name = x.CURRENCY_NAME
    }).ToList(); // Note I materialized the currencies here.
    
    var legalFundClassDetailsViewModel = legalfundClasses.Select(fc => 
    {
        // temp variable
        var ids = otherCurrencies
            .Where(x => x.FUND_CLASS_ID == fc.ID)
            .Select(x => x.CURRENCY_ID)
            .ToArray();
        return new LegalFundClassDetailsViewModel
        {
            OtherCurrencyIds = ids,
            // Query the currency lookup based on the temp variable.
            OtherCurrencyNames = ids.Select(
                id => currencyLookUp.FirstOrDefault(l => l.Id == id)?.Name)
                      .ToArray()
        });
    });
