    public static object GetSalesDataBySaleOrderID(SaleOrder sale)
    {
        return sale.saleOrderItem
                   .Where(s => s != null)
                   .Select(s => new { 
                                      Id = s.Id,
                                      Username = sale.User.GetSingleUserById(s.UserId).Name,
                                      Amount = s.Amount 
                                    })
                   .ToList();
    }
