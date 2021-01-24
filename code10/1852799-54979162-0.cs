    public static IQueryable<DateTimeDirectDebits> ToDateTimeDirectDebits(
        this IQueryable<DirectDebit> directDebits)
    {
        return directDebits.Select(directDebit => new
        {
            // split ExpiryDate into a Month and a Year
            ExpiryDate = new
            {
                Month = DbFunctions.Left(directDebit.DateExpire, 2),
                Year = DbFunctions.Right(directDebit.DateExpire, 2),
            }
            DirectDebit = directDebit,
        })
        .Select(directDebit => new
        {
             // create the ExpiryDate as DateTime
             ExpiryDate = DbFunctions.CreateDateTime(
                directDebit.ExpiryDate.Year,
                directDebit.ExpiryDate.Mnth,
                1,                                // first day of the month
                ...),
             DirectDebit = directDebit.DirectDebit,
        });
    }
