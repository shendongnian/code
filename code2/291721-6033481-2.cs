    var array1 = new double[][]
                {
                  new double[] {1,2,3,4},
                  new double[] {5,6,7,8},
                  new double[] {9,10,11,12}
                };
    
    var array2 = new double[][]
                {
                  new double[] {1,2,5,6},
                  new double[] {7,8,9,10},
                  new double[] {9,10,11,12}
                };
    
    var key = new int[] { 0, 1 };
    
     double?[][] result = (from a in array1
                           from b in array2.Where(bi => key.Select(k => bi[k] == a[k])
                                                           .Aggregate((k1, k2) => k1 && k2))
                                           .DefaultIfEmpty()
                           select a.Select(an => (double?)an)
                                   .Concat(b == null ?
                                           a.Select(an => (double?)null) :
                                           b.Select(bn => (double?)bn))
                                   .ToArray()
                           ).Union
                           (from b in array2
                            from a in array1.Where(ai => key.Select(k => ai[k] == b[k])
                                                            .Aggregate((k1, k2) => k1 && k2))
                                            .DefaultIfEmpty()
                            where a == null
                            select b.Select(bn => (double?)null)
                                    .Concat(b.Select(bn =>(double?)bn))
                                    .ToArray()
                            ).ToArray();
