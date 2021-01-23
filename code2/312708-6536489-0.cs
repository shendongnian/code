    List<AA> AList = Dbcontext.AAs.Where(a => a.ID==4)
        .Select(a => new {a, a.Bobj, a.CCollection})
        .ToList().Select(o => o.a).ToList();
    Dbcontext.Bs.Where(b => b.A.ID==4)
        .Select(b => new {b, b.XCollection})
        .ToList();
    Dbcontext.Cs.Where(c => c.A.ID==4)
        .Select(c => new {c, c.YObj})
        .ToList();
