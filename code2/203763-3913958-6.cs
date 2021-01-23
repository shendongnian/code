    var dict = new Dictionary<string, int[]>
               {
                  { "foo", new[] { 6, 7, 8 } }
                  { "bar", new[] { 1 } }
               };
    
    var fooOrEmpty = dict.GetValueOrEmpty("foo"); // { 6, 7, 8 }
    var barOrEmpty = dict.GetValueOrEmpty("bar"); // { 1 }
    var bazOrEmpty = dict.GetValueOrEmpty("baz"); // {   }
