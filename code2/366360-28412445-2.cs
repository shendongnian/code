    public static DateTime getDateFromFormat(this string _date, string _parsePattern)
            {
                DateTimeOffset dto = DateTimeOffset.ParseExact(_date, _parsePattern, CultureInfo.InvariantCulture);
                return Convert.ToDateTime(dto.ToLocalTime());
            }
