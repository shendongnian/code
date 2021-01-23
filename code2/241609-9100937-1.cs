    public ObservableCollection<T> GetCollection(params SortExpression<T>[] sortExpressions) {
        var list = new ObservableCollection<T>();
        var query = FindAll();
        if (!sortExpressions.Any()) {
            query.ToList().ForEach(list.Add);
            return list;
        }
        var ordered = (sortExpressions[0].Order == SortOrder.Ascending)
            ? query.OrderBy(sortExpressions[0].Expression.Compile())
            : query.OrderByDescending(sortExpressions[0].Expression.Compile());
        for (var i = 1; i < sortExpressions.Length; i++) {
            ordered = sortExpressions[i].Order == SortOrder.Ascending
                ? ordered.ThenBy(sortExpressions[i].Expression.Compile())
                : ordered.ThenByDescending(sortExpressions[i].Expression.Compile());
        }
        ordered.ToList().ForEach(list.Add);
        return list;
    }        
