    string[] searchItems =
        new string[] { "Pattern1", "Pattern2", "Pattern3" };
    var likeExpression = PredicateBuilder.False<U_CDW_REPORT>();
    foreach (string searchItem in searchItems)
    {
        var searchPattern = "%" + searchItem + "%";
        likeExpression = likeExpression.Or(r => 
            SqlMethods.Like(r.CATEGORY, searchPattern));
    }
    return (
        from r in db.U_CDW_REPORTs.Where(likeExpression)
        where r.SI_QTY > 0
        orderby r.SI_QTY descending
        select new Item { ... }).ToList();
