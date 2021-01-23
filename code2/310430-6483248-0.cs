    public static object GetSalesDataBySaleOrderID(SaleOrder sale)
    {
        return sale.saleOrderItem
                   .Select(s => new { 
                                      Id = s.Id,
                                      Username = sale.User.GetSingleUserById(s.UserId).Name,
                                      Amount = s.Amount 
                                    })
                   .ToList();
    }
