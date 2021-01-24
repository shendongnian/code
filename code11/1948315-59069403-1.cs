    RegionInfo us = new RegionInfo("en-US");
    RegionInfo gb = new RegionInfo("en-GB");
    RegionInfo fr = new RegionInfo("fr-FR");
    
    Console.Out.WriteLine(us.CurrencySymbol); // $
    Console.Out.WriteLine(gb.CurrencySymbol); // £
    Console.Out.WriteLine(fr.CurrencySymbol); // €
    
    Console.Out.WriteLine(us.ISOCurrencySymbol); // USD
    Console.Out.WriteLine(gb.ISOCurrencySymbol); // GBP
    Console.Out.WriteLine(fr.ISOCurrencySymbol); // EUR
