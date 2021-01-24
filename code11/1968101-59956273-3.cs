    var stats = UoW.Repository
        .Get(echangeFilter)
        .Select(a=> new {
            Model = MyBLL.IsIncoming(a.idSens)
              ? MyBLL.FindByNoContactModel(a.change.idTo.GetValueOrDefault()) 
              : MyBLL.FindByNoContactModel(a.change.idFrom.GetValueOrDefault()),
            SensAppel = a.echange_sens.nom 
        })
        .GroupBy(a => new
        {
            Id = a.Model.id,
            Tri = a.Model.Tri,
            SensAppel = a.SensAppel
        })
        .Select(group => new
        {
            group.Key.Id, 
            group.Key.Tri,
            Count = group.Count(),
        })
        .OrderBy(g => g.Tri)
        .ToList();
