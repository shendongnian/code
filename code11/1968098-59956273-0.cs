    var stats = UoW.Repository
        .Get(echangeFilter)
        .Select(a=> new {
            IsIncoming = MyBLL.IsIncoming(a.idSens),
            obj = a })
        .Select(a=> a.IsIncoming 
              ? MyBLL.FindByNoContactModel(a.obj.change.idTo.GetValueOrDefault()) 
              : MyBLL.FindByNoContactModel(a.obj.change.idFrom.GetValueOrDefault())
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
