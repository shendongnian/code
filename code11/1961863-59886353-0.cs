x.DataMod.HasValue ? x.DataMod.Value.ToShortDateString() : string.Empty
    void Main()
    {
        var now = DateTime.UtcNow;
        var tomorrow = now.AddDays(1);
    
        var data = new Test[] {
            new Test { DataMod = null },
            new Test { DataMod = now },
            new Test { DataMod = null },
            new Test { DataMod = tomorrow },
            new Test { DataMod = null },
            new Test { DataMod = now }
        };
        
        var keySelector = BuildSelector();
        
        var groups = data
            .GroupBy(keySelector)
            .ToList();
            
        foreach (var group in groups)
        {
            Console.WriteLine($"Group = \"{group.Key}\"");
            Console.WriteLine($"Items = {group.Count()}");
            Console.WriteLine();
        }
    }
    
    class Test
    {
        public DateTime? DataMod { get; set; }
    }
    
    Func<Test, string> BuildSelector()
    {
        // Builds delegate for the Expression: 
        // x => x.DataMod.HasValue ? x.DataMod.Value.ToShortDateString() : string.Empty
        
        // Expression for: x
        var x = Expression.Parameter(typeof(Test), "x");
        
        // Expression for: x.DataMod.HasValue
        var testExpr = Expression.Property(
            Expression.Property(
                x, 
                nameof(Test.DataMod)
            ),
            nameof(Nullable<DateTime>.HasValue)
        );
    
        // Expression for: x.DataMod.Value.ToShortDateString()
        var ifTrueExpr = Expression.Call(
        
            // Expression for: x.DataMod.Value
            Expression.Property(
                Expression.Property(
                    x,
                    nameof(Test.DataMod)
                ),
                nameof(Nullable<DateTime>.Value)
            ),
            
            // Expression for: ToShortDateString
            typeof(DateTime).GetMethod(
                nameof(DateTime.ToShortDateString)
            )
            
            /* args if any */
        );
        
        // Expression for: string.Empty
        var ifFalseExpr = Expression.Field(
            null,
            typeof(string).GetField(nameof(string.Empty))
        );
        
        // Expression for: x => x.DataMod.HasValue ? x.DataMod.Value.ToShortDateString() : string.Empty
        var conditionExpr = Expression.Condition(
            testExpr, 
            ifTrueExpr, 
            ifFalseExpr);
        
        // Compile to a delegate
        var lambda = Expression.Lambda<Func<Test, string>>(conditionExpr, x);
        return lambda.Compile();
    }
