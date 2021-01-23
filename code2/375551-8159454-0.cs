    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }
    }
    public List<QuickFindResult> QueryDocuments(string searchText, string customerSiteId, List<int> filterIds)
    {
        var wildCards = new string[] { "*", "\"" };
        var where = PredicateBuilder.False<vw_QuickFindResult>();
        var searches = new List<String>(searchText.Split(' ')); // TODO: <-- If more complex searches are needed we'll have to use RegularExpressions
        // SEARCH TEXT - WHERE Clause
        searches.ForEach(productName =>
        {
            Boolean hasWildCards = (productName.IndexOfAny(new char[] { '"', '*' }) != -1);
            if (hasWildCards)
            {
                Int32 length = productName.Length;
                if (length > 1)
                {
                    string like = productName.Replace("%", "")
                                             .Replace("*", "");
                    string first = productName.Substring(0, 1);
                    string last = productName.Substring(length - 1);
                    // Contains
                    if (wildCards.Contains(first) && wildCards.Contains(last))
                        where = where.Or(p => p.DocumentName.Contains(like) ||
                                             p.DocumentTitle.Contains(like));
                    // EndsWith
                    else if (wildCards.Contains(first))
                        where = where.Or(p => p.DocumentName.EndsWith(like) ||
                                              p.DocumentTitle.EndsWith(like));
                    // StartsWith
                    else if (wildCards.Contains(last))
                        where = where.Or(p => p.DocumentName.StartsWith(like) ||
                                              p.DocumentTitle.StartsWith(like));
                    // Contains (default)
                    else
                        where = where.Or(p => p.DocumentName.Contains(like) ||
                                              p.DocumentTitle.Contains(like));
                }
                else // Can only perform a "contains"
                    where = where.Or(p => p.DocumentName.Contains(productName) ||
                                                 p.DocumentTitle.Contains(productName));
            }
            else // Can only perform a "contains"
                where = where.Or(p => p.DocumentName.Contains(productName) ||
                                             p.DocumentTitle.Contains(productName));
        });
        // FILTER IDS - WHERE Clause
        var filters = GetAllFilters().Where(x => filterIds.Contains(x.Id)).ToList();
        filters.ForEach(filter =>
        {
            if (!filter.IsSection)
                where = where.And(x => x.FilterName == filter.Name);
        });
        var dataSource = DocumentCollectionService.ListQuickFind(where);
        var collection = new List<QuickFindResult>();
        // Other UNRELATED stuff happens here...
        return collection;
    }
    public static List<vw_QuickFindResult> ListQuickFind(Expression<Func<vw_QuickFindResult, bool>> where)
    {
        var connectionString = GetConnectionString(ES_DOCUMENTS_CONNECTION_NAME);
        List<vw_QuickFindResult> results = null;
        using (HostingEnvironment.Impersonate())
        {
            using (var dataContext = new ES_DocumentsDataContext(connectionString))
            {
                var query = dataContext.vw_QuickFindResults.Where(where).OrderBy(x => x.DocumentName).OrderBy(x => x.DocumentTitle);
                results = query.ToList();
            }
        }
        return results;
    }
