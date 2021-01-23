    public class Grouping<TKey, TElement> : IGrouping<TKey, TElement> {
    
      readonly List<TElement> elements;
      
      public Grouping(IGrouping<TKey, TElement> grouping) {
        Key = grouping.Key;
        elements = grouping.ToList();
      }
      
      public TKey Key { get; private set; }
      
      public IEnumerator<TElement> GetEnumerator() {
        return this.elements.GetEnumerator();
      }
      
      IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
      
    }
