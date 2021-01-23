    public interface IRequiredMember
    {}
    
    public interface IHasNeccesaryMember
    {
      IRequiredMember Member
      {
        get;
        set;
      }
    }
    
    public static IEnumerable<TV> To<TU, TV>(this IEnumerable<TU> source)
                where TV : IHasNeccesaryMember, new()
                where TU : IRequiredMember
     {
        return source.Select(m => new TV{ Member = m });
     }
