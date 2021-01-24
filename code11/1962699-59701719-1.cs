    var itemz = new
    {
        item.Id,
        item.Code,
        item.Name,
        item.Quantity,
        item.BuyPrice,
        item.SalePrice,
        item.CommisionRate,
        item.CategoryID,
        item.UserID,
        item.MeasurementID,
        MftDate = item.MftDate == DateTime.MinValue ? "" : item.MftDate.Value.ToString("dd/MM/yyyy"),
        ExpDate = item.ExpDate == DateTime.MinValue ? "" : item.ExpDate.Value.ToString("dd/MM/yyyy"),
        item.StockLimit,
        item.Description
    };
    
