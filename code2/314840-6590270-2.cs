    public IQueryable GetSearchResults(string PriceFrom, string PriceTo, string Beds, string Baths, string SqftFrom, string SqftTo, string YearFrom, string YearTo)
    {
        DatabaseDataContext db = new DatabaseDataContext();
        string WhereClause = string.Empty;
        if (!string.IsNullOrEmpty(PriceFrom))
            WhereClause = "ListPrice >= " + PriceFrom + " AND ";
        if (!string.IsNullOrEmpty(PriceTo))
            WhereClause += "ListPrice <= " + PriceTo + " AND ";
        if (!string.IsNullOrEmpty(Beds))
            WhereClause += "Beds >= " + Beds + " AND ";
        if (!string.IsNullOrEmpty(Baths))
            WhereClause += "FullBaths >= " + Baths + " AND ";
        if (!string.IsNullOrEmpty(SqftFrom))
            WhereClause += "SqFtHeated >= " + SqftFrom + " AND ";
        if (!string.IsNullOrEmpty(SqftTo))
            WhereClause += "SqFtHeated <= " + SqftTo + " AND ";
        if (!string.IsNullOrEmpty(YearFrom))
            WhereClause += "YearBuilt >= " + YearFrom + " AND ";
        if (!string.IsNullOrEmpty(YearTo))
            WhereClause += "YearBuilt <= " + YearTo + " AND ";
        if (WhereClause.EndsWith(" AND "))
            WhereClause = WhereClause.Remove(WhereClause.Length - 5);
        IQueryable query = db.Listings
                    .Where(WhereClause)
                    .OrderBy("ListPrice descending");
        return query;
    }
