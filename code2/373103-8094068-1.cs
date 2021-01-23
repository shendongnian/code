    public class NewOrderComparer : IEqualityComparer<CollectionCategoryTitle>
    {
      public Equals(CollectionCategoryTitle x, CollectionCategoryTitle y)
      {
         if(ReferenceEquals(x, y)) // same instance
           return true;
         if(x == null || y == null) //both null dealt with already above
           return false;
         return x.NewOrder == y.NewOrder; // again, change for case-insensitive, cultural compare, etc. 
      }
      public GetHashCode(CollectionCategoryTitle obj)
      {
        return obj == null ? 0 : obj.NewOrder.GetHashCode() // once more, change for different string comparisons.
      }
    }
