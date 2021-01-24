    public class FoosManager {
        private Dictionary<string, FooItem> _dic;
      public FooManager(IEnumerable<FooItem> items) {
        if (null == items)
          throw new ArgumentNullException(nameof(items));
        _dic = items.ToDictionary(
           x => x.Id, 
           x => x, 
           tringComparer.OrdinalIgnoreCase);
      }
      public FooItem this[string id] => 
        _dic.TryGetValue(id, out var value) ? value : null;
    } 
