    var result =
         attList2.Select(a => new Attribute(a.WhatAttri, -a.amount)) // line 1
         .Concat(attList1)  // line 2
         .GroupBy(a => a.WhatAttri)  // line 3
         .Select(g => new Attribute(g.Key, g.Sum(a => a.amount)));  // line4
      foreach(var a in result)
      {
        Console.WriteLine($"{a.WhatAttri}: {a.amount}");
      }
