     public IEnumerable<Tuple<string, int>> TestL() {
       return TestList
         .GroupBy(s => s.Postion.ToUpper())
         .Select(chunk => Tuple.Create(d.Key, d.Count()))
         .OrderBy(item => item.Item1); 
     }
