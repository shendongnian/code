    List<T1> t1 = t2.GroupBy(g => new
            {
                g.property1,
                g.property2               
            })
            .Select(g => new T1
            {
                property1 = g.Key.property1,
                property2 = g.Key.property2,                
                BoolProperty =  g.GroupBy(grp => grp.BoolProperty).Count() > 1 ? null : g.Select(g_val=>g_val.BoolProperty).First()
            }).ToList();
