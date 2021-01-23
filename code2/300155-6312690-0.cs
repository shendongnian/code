    var query = CompiledQuery.Compile(
        BuildFolderExpr( folder, false )
            .Select( msg => selector.Invoke( msg, userId ) )
            .OrderBy( mv => mv.DateCreated, SortDirection.Descending )
            .Paging()
            .Expand() // LinqKit method that "injects" referenced expressions
        )
    public static Expression<Func<T1, T2, PagingParam, IQueryable<TItem>>> Paging<T1, T2, TItem>(
        this Expression<Func<T1, T2, IQueryable<TItem>>> expr )
    {
        return ( T1 v1, T2 v2, PagingParam p ) => expr.Invoke( v1, v2 ).Skip( p.From ).Take( p.Count );
    }
