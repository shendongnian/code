    public static class Extensions {
      public static IQueryable<T> ExecuteOrderBys<T>(this OrderByCollection<T> source) {
          // instead of this.xxx use source.xxx
          IQueryable<T> result;
          ...
          if (source.Skip != null)
            result = source.Skip(this.Skip.Value);
          if (source.Take != null)
            result = source.Take(this.Take.Value);
          ...
      } 
    }
