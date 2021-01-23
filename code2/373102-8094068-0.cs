    public class CollectionCategoryTitle : IEquatable<CollectionCategoryTitle>
    {
      public long CollectionTitleId { get; set; }
      public bool CollectionTitleIdSpecified { get; set; }
      public string SortOrder { get; set; }
      public TitlePerformance performanceField { get; set; }      
      public string NewOrder { get; set; }
      //implementing IEquatable<CollectionCategoryTitle> is optional but more efficient and convenient
      public bool Equals(CollectionCategoryTitle other)
      {
        return other != null && NewOrder == other.NewOrder;
        //adjust string comparison if plain == isn't the appropriate comparator,
        //e.g. case insensitive
      }
      public override bool Equals(object other)
      {
        return Equals(other as CollectionCategoryTitle);
      }
      public override int GetHashCode()
      {
        return NewOrder.GetHashCode();
        //adjust if different string comparison is appropiate
        //e.g. return StringComparer.CurrentCultureIgnoreCase.GetHashCode(NewOrder)
        //for current-culture case-insensitive.
      }
    }
