    var nfi = new System.Globalization.CultureInfo( "en-GB", false ).NumberFormat;   
    nfi.CurrencyPositivePattern = 2;
    var a = string.Format(nfi, "{0:C}", 112.236677);
    
    // Output will be £ 112.24
