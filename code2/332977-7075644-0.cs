    if(sil != null)
    {
       var iweil = sil.Select(item=>new InvoiceWithEntryInfo()
                {
                    IdIWEI = item.ID,
                    AmountIWEI = item.Amount,
                    DateIWEI = item.Date
                }).ToList();
    }
