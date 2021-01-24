     using System.Linq;
     ...
     int groupSize = 5;
     var result = MyList
       .Select((item, index) => new {
          item,
          index 
        })
       .GroupBy(pair => pair.index / groupSize, 
                pair => pair.item)
       .Select(group => group.ToList())
       .ToList(); 
  
