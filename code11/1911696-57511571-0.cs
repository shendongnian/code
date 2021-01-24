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
                 Ca = C.a,
                 Cb = C.b,
                 Cc = C.c
             })
             .GroupBy(x => new {x.Ba, x.Bb, x.Bc})
             .SelectMany(grp => new {
                 Column1 = grp.Aa,
                 Column2 = grp.Ab,
                 Column3 = grp.Ac,
                 Column4 = grp.Sum(y => y.Cd),
                 Column5 = grp.Be
             }).ToList();
