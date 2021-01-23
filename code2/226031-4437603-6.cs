    public class AppleRepository : DataRepository<Apple>
    {
       public AppleRepository(IObjectContext ctx) : base(ctx) {}
 
       public ICollection<Apple> FindApples(Func<Apple,bool> predicate)
       {
          return CurrentEntitySet.Where(predicate).ToList();
       }
    }
