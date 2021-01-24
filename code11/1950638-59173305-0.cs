      using System.Linq;
      ...
      var class1List = ...
   
      var result = class1List
        .GroupBy(item => new {
           id1 = item.Id,
           id2 = item.details?.Id,   
         })
        .Select(group => new {
           id1 = group.Key.id1, 
           id2 = group.Key.id2,  
           count = group.Count()
         }) 
        .OrderBy(item => item.id1) // Not necessary, but let's represent counts
        .ThenBy(item => item.id2); // in some order
