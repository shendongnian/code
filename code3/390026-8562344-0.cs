    var left = 
        from x in list1
        join y in list2
            on new { x.Title, x.Classification }
            equals { y.Title, y.Classification }
            into tmp
        from y in tmp.DefaultIfEmpty()
        select Tuple.Create(x, y);
    var right = 
        from y in list2
        join x in list1
            on new { y.Title, y.Classification }
            equals { x.Title, x.Classification }
            into tmp
        from y in tmp.DefaultIfEmpty()
        where x == null // already included in left
        select Tuple.Create(x, y);
    var result = left.Concat(right);
