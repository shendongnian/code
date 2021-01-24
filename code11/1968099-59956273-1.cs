    var stats = UoW.Repository
        .Get(echangeFilter)
        .Select(a=> MyBLL.IsIncoming(a.idSens)
              ? MyBLL.FindByNoContactModel(a.change.idTo.GetValueOrDefault()) 
              : MyBLL.FindByNoContactModel(a.change.idFrom.GetValueOrDefault())
         )
        .GroupBy(a => new
        {
            Id = a.id,
            Tri = a.Tri
        })
        .Select(group => new
        {
            group.Key.Id, 
            group.Key.Tri,
            Count = group.Count(),
        })
        .OrderBy(g => g.Tri)
        .ToList();
