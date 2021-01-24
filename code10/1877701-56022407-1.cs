    var comparer = Comparer<Point>.Create((p1, p2) =>
    {
        if (p1.y < p2.y)
        {
           return p1.x > p2.x ? 1 : -1;
        } 
        else
        {
           return p1.x < p2.x ? 1 : -1;
        }
    });
    
    hashset.OrderBy(p => p, comparer)
