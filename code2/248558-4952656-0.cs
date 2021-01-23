    private static Expression<Func<Record, bool>> Filter(string term)
    {
      return r => r.Field1.ToLower().Contains(term);
    }
    
    var results = DataContext.Records.Where(Filter(term));
