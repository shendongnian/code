    public class FoosManager {
      private Dictionary<string, FooItem> _dic;
      public FooManager(IEnumerable<FooItem> items) {
        if (null == items)
          throw new ArgumentNullException(nameof(items));
        // Let's do it in one go:
        _dic = items.ToDictionary(
           item => item.Id, 
           item => item, 
           StringComparer.OrdinalIgnoreCase);
      }
      // No need in GetItem, ContainsKey etc.
      public FooItem this[string id] => 
        _dic.TryGetValue(id, out var value) ? value : null;
    } 
