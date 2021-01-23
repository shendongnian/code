    // Create full join of selection
    var fullJoin = (from l in array1
                    join r in array2 on new Keys(l, keyArray) equals new Keys(r, keyArray) into g
                    from r in g.DefaultIfEmpty()
                    select new { l, r})
                   .Concat
                   (from r in array2
                    join l in array1 on new Keys(r, keyArray) equals new Keys(l, keyArray) into g
                    from l in g.DefaultIfEmpty()
                    where l == null
                    select new {l, r});
                    
    // Create the final result set
    var results = fullJoin.Select(i => 
    { 
        var list = new List<double?>(); 
        if (i.l != null)
        {
            list.AddRange(i.l); 
        }
        else
        {
            list.AddRange(Enumerable.Repeat((double?)null, i.r.Length));
        }
        if (i.r != null)
        {
            list.AddRange(i.r); 
        }
        else
        {
            list.AddRange(Enumerable.Repeat((double?)null, i.l.Length));
        }
        return list.ToArray();
    }).ToArray();
