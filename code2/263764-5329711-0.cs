    source.GroupBy(s => new
                        {
                          Value1 = s.Value1,
                          Value2 = s.Value2,
                          Value3 = s.Value3,
                          Value4 = s.value4
                        })
          .Select(g => new TestObject
                       {
                          Value1 = g.Key.Value1,
                          Value2 = g.Key.Value2,
                          Value3 = g.Key.Value3,
                          Value4 = g.Key.value4,
                          Num1 = g.Sum(s => s.Num1),
                          Num2 = g.Sum(s => s.Num2)
                       });
