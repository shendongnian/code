var indInfoTemp = list1.Where(ind => ind.IL.Any(il => list2.Contains(il.PIN)))
                       .Select(ind => new { 
                                 ind.TPN, 
                                 IL = ind.IL.Where(il => list2.Contains(il.PIN))
                                            .ToList()
                         })
                       .ToList();
