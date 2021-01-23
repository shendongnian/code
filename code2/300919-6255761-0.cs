    public static class MyHelperExtensions 
    {    
            public static DateTime ParseDateAsString(this string value)
            {
                var culture = new CultureInfo("nb-NO");
                var formats = new[] {"ddMMyyyy", "dd.MM.yyyy"};
                DateTime date;
                return DateTime.TryParseExact(value, formats, culture, DateTimeStyles.None, out date) ? date : DateTime.MinValue;
            }
    }
