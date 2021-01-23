    public static IQueryable<T> _GroupMaxs<T, TGroupCol, TValueCol>
        (this IQueryable<T> list, string groupColName, string valueColName)
    {
        // (x => x.groupColName)
        var _GroupByPropInfo = typeof(T).GetProperty(groupColName);
        var _GroupByParameter = Expression.Parameter(typeof(T), "x");
        var _GroupByProperty = Expression
                .Property(_GroupByParameter, _GroupByPropInfo);
        var _GroupByLambda = Expression.Lambda<Func<T, TGroupCol>>
            (_GroupByProperty, new ParameterExpression[] { _GroupByParameter });
        // (x => x.valueColName)
        var _SelectParameter = Expression.Parameter(typeof(T), "x");
        var _SelectProperty = Expression
                .Property(_SelectParameter, valueColName);
        var _SelectLambda = Expression.Lambda<Func<T, TValueCol>>
            (_SelectProperty, new ParameterExpression[] { _SelectParameter });
        // return list.GroupBy(x => x.groupColName)
        //   .Select(g => g.OrderByDescending(x => x.valueColName).First());
        return list.GroupBy(_GroupByLambda)
            .Select(g => g.OrderByDescending(_SelectLambda.Compile()).First());
    }
