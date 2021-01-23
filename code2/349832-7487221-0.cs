     var checksum =
         new [] {
             code
                .Reverse()
                .Select((c, index) => new {
                    IsIndexOdd = index % 2 != 0,
                    Value = (int) Char.GetNumericValue(c)
                })
                .Select(x => x.IsIndexOdd ? x.Value : 3 * x.Value)
                .Aggregate((a, b) => a + b)
         }
         .Select(x => new { Rounded = ((x + 10 - 1) / 10) * 10, Intermediate = x })
         .Select(x => x.Rounded - x.Intermediate)
         .Single();
