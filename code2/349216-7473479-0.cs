    public class SomeObjectSet
    {
         public int TotalSetCount { get; set; }
         public List<SomeObject> Items { get; set; }
         public SomeObjectSet(List<SomeObject> subset, int totalCount)
         {
              items = subset;
              TotalSetCount = totalCount;
         }
    }
