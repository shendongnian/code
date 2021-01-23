    public static IEnumerable<T> OrderByMany<T>(this IEnumerable<T> enumerable,
        params Tuple<Expression<Func<T, object>>,SortOrder>[] expressions)
    {
    
        var query = (expressions[0].Item2 == SortOrder.Ascending)
                        ? enumerable.OrderBy(expressions[0].Item1.Compile())
                        : enumerable.OrderByDescending(expressions[0].Item1.Compile());
               
        for (int i = 1; i < expressions.Length; i++)
        {
            query = expressions[i].Item2 == SortOrder.Ascending
                        ? query.ThenBy(expressions[i].Item1.Compile())
                        : query.ThenByDescending(expressions[i].Item1.Compile());
        }
        return query;
    
    }
             
