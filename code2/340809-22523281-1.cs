       private Func<T, object> GetOrderByExpression<T>(string sortColumn)
        {
            Func<T, object> orderByExpr = null;
            if (!String.IsNullOrEmpty(sortColumn))
            {
                Type sponsorResultType = typeof(T);
                if (sponsorResultType.GetProperties().Any(prop => prop.Name == sortColumn))
                {
                    System.Reflection.PropertyInfo pinfo = sponsorResultType.GetProperty(sortColumn);
                    orderByExpr = (data => pinfo.GetValue(data, null));
                }
            }
            return orderByExpr;
        }
        public List<T> OrderByDir<T>(IEnumerable<T> source, string dir, Func<T, object> OrderByColumn)
        {
            return dir.ToUpper() == "ASC" ? source.OrderBy(OrderByColumn).ToList() : source.OrderByDescending(OrderByColumn).ToList();``
        }
     // Call the code like below
            var orderByExpression= GetOrderByExpression<SearchResultsType>(sort);
        var data = OrderByDir<SponsorSearchResults>(resultRecords, SortDirectionString, orderByExpression);    
