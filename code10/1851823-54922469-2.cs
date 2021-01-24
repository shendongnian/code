    public List<(string, int)> TestL() //or IEnumerable?
    {
        var q1 = TestList.GroupBy(s => s.Postion.ToUpper())
                         .Select(d =>
                          {
                               return new
                               {
                                   NameDisplay = d.Key,
                                   Count = d.Count()
                               };
                          })
                         .OrderBy(g => g.NameDisplay)  
                         .Select(x => (x.NameDisplay, x.Count))
                         .ToList();
        return q1;
    }
    
