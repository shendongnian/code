    var items = myContext.AsEnumerable()
                         .Select(item => new {
                                     Value1 = TweakValue(item.Value1),
                                     Value2 = TweakValue(item.Value2)
                                 });
