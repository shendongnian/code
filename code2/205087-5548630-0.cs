      static private List<String> AcceptableDateFormats = new List<String>(180);
      static Boolean IsDate(Object value, DateTimeFormatInfo formatInfo)
      {
         if (AcceptableDateFormats.Count == 0)
         {
            foreach (var dateFormat in new[] { "d", "dd" })
            {
               foreach (var monthFormat in new[] { "M", "MM", "MMM" })
               {
                  foreach (var yearFormat in new[] { "yy", "yyyy" })
                  {
                     foreach (var separator in new[] { "-", "/", formatInfo.DateSeparator  })
                     {
                        String shortDateFormat;
                        shortDateFormat = dateFormat + separator + monthFormat + separator + yearFormat;
                        AcceptableDateFormats.Add(shortDateFormat);
                        AcceptableDateFormats.Add(shortDateFormat + " " + "HH:mm");
                        AcceptableDateFormats.Add(shortDateFormat + " " + "HH:mm:ss");
                        AcceptableDateFormats.Add(shortDateFormat + " " + "HH" + formatInfo.TimeSeparator + "mm");
                        AcceptableDateFormats.Add(shortDateFormat + " " + "HH" + formatInfo.TimeSeparator + "mm" + formatInfo.TimeSeparator + "ss");
                     }
                  }
               }
            }
            AcceptableDateFormats = AcceptableDateFormats.Distinct().ToList();
         }
         DateTime unused;
         return DateTime.TryParseExact(value.ToString(), AcceptableDateFormats.ToArray(), formatInfo, DateTimeStyles.AllowWhiteSpaces, out unused);
      }
