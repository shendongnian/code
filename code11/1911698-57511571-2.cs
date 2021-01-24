var model = (from A in tableA
             join B in tableB on new { A.a, A.b, A.c } equals new { B.a, B.b, B.c }
             join C in tableC on new { A.a, A.b, A.c }  equals new { C.a, C.b, C.c }
             select new {
                 Aa = A.a,
                 Ab = A.b,
                 Ac = A.c,
                 Ba = B.a,
                 Bb = B.b,
                 Bc = B.c,
                 Be = B.e,
                 Ca = C.a,
                 Cb = C.b,
                 Cc = C.c,
                 Cd = C.d
             })
             .GroupBy(x => new {x.Ba, x.Bb, x.Bc})
             .Select(grp => new {
                 Column1 = grp.First().Aa,
                 Column2 = grp.First().Ab,
                 Column3 = grp.First().Ac,
                 Column4 = grp.Sum(y => y.Cd),
                 Column5 = grp.First().Be
             }).ToList();
