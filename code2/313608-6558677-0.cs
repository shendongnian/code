    public class R {
       public int Id {get; set;}
    }
    
    public IEnumerable<R> InClause(IEnumerable<int> ids) {
       var subset = ids.ToList();
    
       return dbContext.Query<R>.Where(r => subset.Contains(r.Id));
    }
