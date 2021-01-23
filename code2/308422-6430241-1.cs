    var items =  myContext.Select(i => new {
                     Value1 = item.Value1,
                     Value2 = item.Value2
                 })
                 .AsEnumerable()
                 .Select(i => new {
                     Value1 = TweakValue(item.Value1),
                     Value2 = TweakValue(item.Value2)
                  });
