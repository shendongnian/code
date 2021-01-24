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
            item.MftDate.ToString("dd/MM HH:mm:ss"),
            item.ExpDate.ToString("dd/MM/yyyy"),
            item.StockLimit,
            item.Description
        };
        return Json(new { data = itemz }, JsonRequestBehavior.AllowGet);
