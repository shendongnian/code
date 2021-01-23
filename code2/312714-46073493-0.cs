    var properties = inv.GetType().GetProperties();
    
    foreach (var prop in properties)
    {
        if (prop.ToString().ToLower().Contains("decimal"))
        {
            totalDecimal += (Decimal)prop.GetValue(inv, null);
        }
    }
