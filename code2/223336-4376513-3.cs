    public static List<Booking> Today(DateTime begin, DateTime end)
    {
        try
        {
            dbDataContext db = new dbDataContext();
            IEnumerable<timerangeResult> bQ = from b in db.timerange(begin, end)
                                 select b;
            List<Booking> bL = timerangeResult.ToBookingList(bQ);
            return bL;
        }
        catch (Exception)
        {
            throw;
        }
    }
