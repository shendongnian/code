    public interface IFoo
    {
        int DomainId { get; set; }
    }
    ..
    public static IQueryable<T> ExecuteInContext<T>(IQueryable<T> src) where T: IFoo
    {
      int domain = 1;//hard coded for example
      return src.Where(x => x.DomainID == domain);
    }
