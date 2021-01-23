    private static DateTime? toDate(string probDate)
    {
        if (!string.IsNullOrWhiteSpace(probDate)) {
            DateTime converted;
            if (DateTime.TryParse(probDate, out converted))
            {
                return converted;
            }
        }
        return null;
    }
