    public class AppleRepository : DataRepository<Apple>
    {
       public ICollection<Apple> FindApples(Func<Apple,bool> predicate)
       {
          return CurrentEntitySet.Where(predicate).ToList();
       }
    }
