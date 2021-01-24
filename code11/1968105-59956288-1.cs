    var query = from a in UoW.Repository
        .Get(echangeFilter)
        let x = MyBLL.IsInComing(a.idSens) ? MyBLL.FindByNoContactModel(a.change.idTo.GetValueOrDefault()) : MyBLL.FindByNoContactModel(a.change.idFrom.GetValueOrDefault())
        group a by new
        {
            Id = x.id,
            Tri = x.Tri,
            SensAppel = a.echange_sens.nom
        } into g
        let b = new
        {
            g.Key.Id, 
            g.Key.Tri,
            Count = g.Count(),
        }
        orderby g.Tri
        select g;
    var stats = query.ToList();
