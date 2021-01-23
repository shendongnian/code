    int a = 2;
    int b = 10;
    
    // a < x <= b
    var interval1 = new HashSet<int>(Enumerable.Range(a + 1, b - a));
    
    // Dump is a LINQPad extension method.
    interval1.Dump();
    // 3..10
    
    // Check if point in interval
    interval1.Contains(a).Dump();
    // False
    interval1.Contains(b).Dump();
    // True
    
    var overlappingInterval = new HashSet<int>(Enumerable.Range(9, 3));
    overlappingInterval.Dump();
    // 9, 10, 11
    
    var nonOverlappingInterval = new HashSet<int>(Enumerable.Range(11, 2));
    nonOverlappingInterval.Dump();
    // 11, 12
    
    interval1.Overlaps(overlappingInterval).Dump();
    // True
    
    interval1.Overlaps(nonOverlappingInterval).Dump();
    // False
    
    interval1.UnionWith(overlappingInterval);
    interval1.Dump();
    // 3..11
    // Alternately use LINQ's Union to avoid mutating.
    // Also IntersectWith, IsSubsetOf, etc. (plus all the LINQ extensions).
