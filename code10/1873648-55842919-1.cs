var result = items
    .GroupBy(item => item.Name)
    .SelectMany(g =>
    {
       if (g.Count() > 1 && g.Key == "A") //g.Key.StartsWith("A")
         return g;
    });
This will return u an array where will be all `"A"` elements and then u could decide which u'd like to delete
To delete all duplicates and leave only the last inserted element:
var result = items
    .GroupBy(item => item.Name)
    .SelectMany(g =>
    {
       if (g.Count() > 1)
       {
          var mainElement = g.OrderByDescending(x => x.ID).First();
          return g.Where(x => x.ID != mainElement.ID).ToArray();
       }
    });
