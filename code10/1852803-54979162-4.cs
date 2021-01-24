    public static IQueryable<DateTimeDirectDebit> WhereExpiresWithinDays(
       this IQueryable<DateTimeDirectDebit> source,
       int nrOfDays)
    {
        DateTime now = DateTime.now;
        DateTime limitDate = now.AddDays(nrOfDays);
        return source.Where(directDebit => directDebit.ExpiryDate < limitDate);
    }
