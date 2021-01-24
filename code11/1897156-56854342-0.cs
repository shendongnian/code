    using System.Linq;
    ...
    _entries = new List<string>() {
       "Awesom",
       "Awesom",
       "Awesom",
       "Awesom",
       "Foo",
       "Bar",
       "Bar",   
    };
    int count = _entries
      .GroupBy(item => item)    
      .Sum(group => group.Count() - 1);
