    public DateTimeOffset ReadStringWithTimeZone(string EnteredDate, TimeZoneInfo tzi)
    {
        DateTimeOffset cvUTCToTZI = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, tzi);
        DateTimeOffset cvParsedDate = DateTimeOffset.MinValue;
        DateTimeOffset.TryParse(EnteredDate + " " + cvUTCToTZI.ToString("zzz"), out cvParsedDate);
        if (tzi.SupportsDaylightSavingTime)
        {
            TimeSpan getDiff = tzi.GetUtcOffset(cvParsedDate);
            string MakeFinalOffset = (getDiff.Hours < 0 ? "-" : "+") + (getDiff.Hours > 9 ? "" : "0") + getDiff.Hours + ":" + (getDiff.Minutes > 9 ? "" : "0") + getDiff.Minutes;
            DateTimeOffset.TryParse(EnteredDate + " " + MakeFinalOffset, out cvParsedDate);
            return cvParsedDate;
        }
        else
        {
            return cvParsedDate;
        }
    }
