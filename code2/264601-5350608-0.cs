    public enum ContainedIn
    {
        AOnly,
        BOnly,
        Both
    }
)
    var la = new List<int> {1, 2, 3};
    var lb = new List<int> {2, 3, 4};
    var l1 = la.Except(lb)
               .Select(i => new Tuple<int, ContainedIn>(i, ContainedIn.AOnly));
    var l2 = lb.Except(la)
               .Select(i => new Tuple<int, ContainedIn>(i, ContainedIn.BOnly));
    var l3 = la.Intersect(lb)
               .Select(i => new Tuple<int, ContainedIn>(i, ContainedIn.Both));
    var combined = l1.Union(l2).Union(l3);
