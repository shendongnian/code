cs
var stats = UoW.Repository
.GroupBy(a => {
    var repo = MyBLL.IsInComing(a.idSens) ? MyBLL.FindByNoContactModel(a.change.idTo.GetValueOrDefault()) : MyBLL.FindByNoContactModel(a.change.idFrom.GetValueOrDefault())
    return new
    {
        Id = repo.id,
        Tri = repo.Tri,
        SensAppel = a.echange_sens.nom
    }
    
})
.Select(group => new
{
    group.Key.Id, 
    group.Key.Tri,
    Count = group.Count(),
})
.OrderBy(g => g.Tri)
.ToList();
