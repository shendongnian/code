    var leftJoin = Table1
                   .GroupJoin(Table2,
                   T1 => T1.Col1,
                   T2 => T2.Col2,
                   (T1, ms) => new { T1, ms })
                   .SelectMany(z => z.ms.DefaultIfEmpty()
                   .Select(T2 => new {T1 = z.T1, T2 }));
