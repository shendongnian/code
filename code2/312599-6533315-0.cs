    public void Search(SearchTerms Query)
    {
        var queryWithLocation = db.branches.Where(b =>
              Query.Location.Equals(b.Location, StringComparison.OrdinalIgnoreCase);
        var query = Query.Location != null ? queryWithLocation : db.branches;
    }
