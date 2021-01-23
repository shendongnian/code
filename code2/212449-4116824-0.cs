    IEnumerable<int> InclusiveRange(int s, int e) {
       for (int i = s; i <= e; i++) {
         yield return i;
       }
    }
    
    var r = InclusiveRange(1930, 2010).ToList();
