    var selectedResults = Results
      .OrderBy(item => item.Result != 0) // items with Result == 0 first
      .ThenBy(item => item.Result == 0   // if items.Result == 0 then by Id
         ? item.id
         : int.MaxValue)                 // I've assumed id is int
      .ThenBy(item => item.Result);      // finally by Result
