    using System.Linq;
    ...
    var SPFK_List = new List<string>() {
      "one", "one", "one",
      "two", "two", 
      "three", "three", "three"
    };
    // {3, 2, 3}
    int[] counts = SPFK_List
      .GroupBy(item => item)
      .Select(group => group.Count())
      .ToArray();
