    public static string GetPropertyWithFallback(Item item, Func<Item, string> getter) {
	  if (item != null) {
        var val = getter(item);
        if (!string.IsNullOrEmpty(val)) {
          return val;
        }
	  }
      return "Not available";
	}
	public static void Main() {
      var mainList = new List<Item>();
      var firstItem = mainList.FirstOrDefault();
      var name = GetPropertyWithFallback(firstItem, i => i.Name);
      var descr = GetPropertyWithFallback(firstItem, i => i.Descr); 
      //etc.
    }
