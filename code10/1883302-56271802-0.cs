    public List<Something> Fetch(bool? allocated = null)
    {
         var query = DbContext.Something.Where(x => x.Active);
         if (allocated != null)
         {
             // Do this outside the lambda expression, so it's just bool in the expression tree
             bool allocatedValue = allocated.Value;
             query = query.Where(x => x.Allocated == allocatedValue);
         }
         return query.ToList();
    }
