    data.Data = await query.Select(s => new AdvanceIn()
        {
           Count = s.Count(),
           NetAmountSum = s.Select(t => t.NetAmount).Sum(),
           GrossAmountSum = s.Select(t => t.Transaction.GrossAmountWithoutSaleDiscount).Sum(),
           AdminSale =  s.AdminSale.OrderBy(/* ?? */).Select(a => new SaleTransferReadModel 
           {
               Id = a.Id,
               PlaceName = a.PlaceName,
               PlacePhoto = a.PlacePhoto
           }).First(),
           PayIn = s.Select(t => t.PayIn).First(), // Nope! don't return an Entity. Get a value or create a ViewModel like SaleTransferReadModel.
           SaleTransactionId = String.Join(",", s.Select(x => x.Id.ToString())) // This might not work for EF2SQL... Consider returning the list of IDs and projecting to a Display String in the ViewModel.
        }).OrderBy(s => s.PayIn)
        .Skip(limit.Value * page)
        .Take(limit.Value)
        .ToListAsync();
