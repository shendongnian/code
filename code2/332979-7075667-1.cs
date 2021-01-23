    var iweilCopy = sil.Select(item => new InvoiceWithEntryInfo()
    {
      IdWEI = item.Id,
      NameWEI = item.Name,
      ....
    }).ToList();
