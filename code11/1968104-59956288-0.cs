    var query = from a in UoW.Repository
        .Get(echangeFilter)
        group a by new
        {
            Id = MyBLL.IsInComing(a.idSens) ? MyBLL.FindByNoContactModel(a.change.idTo.GetValueOrDefault()).id : MyBLL.FindByNoContactModel(a.change.idFrom.GetValueOrDefault()).id,
            Tri = MyBLL.IsInComing(a.idSens) ? MyBLL.FindByNoContactModel(a.change.idTo.GetValueOrDefault()).Tri: MyBLL.FindByNoContactModel(a.change.idFrom.GetValueOrDefault()).Tri,
            SensAppel = a.echange_sens.nom
        } into g
        let b = new
        {
            group.Key.Id, 
            group.Key.Tri,
            Count = group.Count(),
        }
        orderby g.Tri
        select g;
    var stats = query.ToList();
