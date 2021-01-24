    using System.Linq;
    ...
    // No Sequential Order test
    var _entries = new List<string>() {
       "Awesom",
       "Bar",
       "Awesom",
       "Awesom",
       "Foo",
       "Awesom",
       "Bar",   
    };
    int count = _entries
      .GroupBy(item => item)    
      .Sum(group => group.Count() - 1);
