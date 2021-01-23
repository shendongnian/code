    using System.Linq;
    ...
    var sortedDictionary = 
            myDictionary.OrderByDescending(x => x.Value)
                        .ThenByDescending(x => x.Key)
                        .ToDictionary(x => x.Key, x => x.Value);
