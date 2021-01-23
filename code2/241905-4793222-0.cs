    public class MyList<T> : System.Collections.Generic.List<T>
    {
      public IEnumerable<T> MyFind(Predicate<T> match)
      {
        return this.Where(x => x.CanSeeThis).ToList().Find(match);
      }
    }
