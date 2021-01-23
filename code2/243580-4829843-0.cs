    List<Listing> list = condition ? QueryList<Listing_UK>() 
                                   : QueryList<Listing_US>();
    private static List<Listing> QueryList<T>() where T : Listing
    {
        return DBSession.QueryOver<T>()
                        .Where(l => l.Field == "value")
                        .List<Listing>();
    }
