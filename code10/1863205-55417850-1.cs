    // If Previoussoftcloses == null we can do nothing, let's check for this possibility
    if (Previoussoftcloses != null) {
      // Dictionary is faster then List on Contains O(1) vs. O(N)
      var previous = Previouscloses
        .GroupBy(item => item.Id)  
        .ToDictionary(chunk => chunk.Key, chunk => chunk.First());
      // Readability: what we are going to scan
      var current = Currentcloses
        .Where(c => c.Status == ReferenceEnums.ActionStatus.EDIT); 
    
      foreach (var cscData in current) { 
        if (previous.TryGetValue(cscData.Id, out var pscData)) {
          //my logic goes here
        }
      }
    }
