    IQueryable<History<T>> GetFirstOperationsForEveryId<T>
    (IQueryable<History<T>> ItemHistory)
    {
    var grouped = (from h1 in ItemHistory
                   group t by h1.GenericId into tt
                   select new
                   {
                        GenericId = tt.Key,
                        OperationId = tt.Min(ttt => ttt.OperationId)
                   });
    var q = (from h in ItemHistory
             join g in grouped
                on new { h.OperationId, h.GenericId }
                equals new { g.OperationId, g.GenericId }
             select h);
    return q;
    }
