    var stats = UoW.Repository
        .Get(echangeFilter)
        .Select(a => new {
            a.echange_sens.nom,
            fncm = MyBLL.FindByNoContactModel(
                       (MyBLL.IsInComing(a.idSens)
                           ? a.change.idTo
                           : a.change.idFrom)
                       .GetValueOrDefault())
        })
        .GroupBy(nf => new {
            Id = nf.fncm.id,
            Tri = nf.fncm.Tri,
            SensAppel = nf.nom
        })
        .Select(group => new {
            group.Key.Id,
            group.Key.Tri,
            Count = group.Count(),
        })
        .OrderBy(g => g.Tri)
        .ToList();
