    List<A> myAs = ...;
    List<B> myBs = ...;
    var pairs = from a in myAs
                join b in myBs on a.Something1 equals b.Anything1 into TheseBs
                select new { A = a, TheseBs };
    foreach (var pair in pairs)
    {
        pair.A.Something3.AddRange(pair.TheseBs);
    }
