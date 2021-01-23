    var TheQuery = from ....
                   where ....
                   let subquery = (...... )
                   select new MyObject()
                   {
    
                     Prop1 = subquery!=null ? subquery.Sum( d => d) : 0;
    
                   }.ToList();
