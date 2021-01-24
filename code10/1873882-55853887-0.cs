    public static IEnumerable<DateTime> GetAvailableDates(int id)
    {
        DateTime startDate = DateTime.Today;
        DateTime endDate = new DateTime(2019, 12, 31);
        var bookedDates = GetBookedDates(id);
        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
        {
            if (bookedDates.Any(range => date >= range.Arrive && date <= range.Depart)) continue;
            yield return date;
        }
    }
