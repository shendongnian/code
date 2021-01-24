     public IEnumerable<(string, int)> TestL() {
       return TestList
         .GroupBy(s => s.Postion.ToUpper())
         .Select(chunk => (NameDisplay: d.Key, Count: d.Count()))
         .OrderBy(item => item.NameDisplay); 
     }
