        public Dictionary<string, List<string>> CreateSuggestionsLists<T>(List<T> data)
        {
            var queryableData = data.AsQueryable();
            var paramExp = Expression.Parameter(typeof(T), "left");
            foreach (var pi in typeof(T).GetProperties().Where(p => p.PropertyType == typeof(string)))
            {
                var callExpr = Expression.MakeMemberAccess(paramExp, pi);
                var lambdaExpr = Expression.Lambda<Func<T, bool>>(callExpr, paramExp);
                var res = queryableData.Select(lambdaExpr).Distinct().ToList();
                // add to results ...
            }
            return null;
        }
