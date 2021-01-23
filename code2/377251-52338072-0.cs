    // project reference to System.Globalization
    using System.Globalization;
        
    // example uses properties of an en-US DateTimeFormatInfo object
    DateTimeFormatInfo dtfi = CultureInfo.GetCultureInfo("en-US").DateTimeFormat;
        
    // date time string to format
    "2018-09-07 00:00:00".ToString("MMMM d, yyy", dtfi).ToUpper());
    
    // result
    SEPTEMBER 7, 2018
