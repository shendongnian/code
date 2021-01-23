    var items = myContext.Select(item => new { item.Value1, item.Value2 })
                         .AsEnumerable()
                         .Select(item => new {
                                     Value1 = TweakValue(item.Value1),
                                     Value2 = TweakValue(item.Value2)
                                 });
