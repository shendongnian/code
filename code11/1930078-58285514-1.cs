       // Some kind of test value
       string value = DateTime.Now.ToString(new CultureInfo("en-US"));
       ...
       string[] formats = { 
         "R",                  // RFC1123 e.g. 2019-10-08T14:39:47
         "yyyy-M-d",
         "yyyy-M-d H:m:s",
         "M/d/yyyy",           // en-US special: date only
         "M/d/yyyy H:m:s",     // en-US special: date and 24 hour time
         "M/d/yyyy h:m:s tt",  // en-US special: date and 12 hour time
       };       
       DateTime outDate;
       if (DateTime.TryParseExact(value, 
                                  formats,
                                  new CultureInfo("en-US"),
                                  DateTimeStyles.None, out outDate)) {
           // Parsing succeeded
           interfaceoperation.LogDate = outDate;
           interfaceoperation.LogTime = outDate;
       }
       else
       {
           // Parsing failed
       }  
