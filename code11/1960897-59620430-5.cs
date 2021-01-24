    foreach (var bill in bills)
    {
        var rates =
            items.Where(item => item.Id == bill.ItemId && item.EffectiveDate <= bill.Date)
                .GroupBy(item => item.EffectiveDate)
                .OrderBy(grp => grp.Key)
                .LastOrDefault();
        Console.WriteLine($"For bill {bill}: ");
        Console.WriteLine(rates == null 
            ? " - [No rates]" 
            : $" - {string.Join("\r\n - ", rates)}");
        Console.WriteLine();
    }
