    var dict = new Dictionary<string, int[]>
               {
                  { "foo", new[] { 6, 7, 8 } }
                  { "bar", new[] { 1 } }
               };
    
    var fooOrEmpty = dict.GetValueOrEmpty<string, int, int[]>("foo"); // { 6, 7, 8 }
    var barOrEmpty = dict.GetValueOrEmpty<string, int, int[]>("bar"); // { 1 }
    var bazOrEmpty = dict.GetValueOrEmpty<string, int, int[]>("baz"); // {   }
