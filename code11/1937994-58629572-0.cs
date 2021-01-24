var dbList = _apiDbContext.StepResult
               .ToList();
List<Steps> steps = dbList.Where(x => x.parentID == null).Select(x => new Steps { id = x.id, name = x.name }).ToList();
steps.ForEach(x => Sample(x, dbList));
public class Steps
{
    public int id { get; set; }
    public string name { get; set; }
    public List<Steps> childs { get; set; }
}
public void Sample(Steps step, List<DbSteps> dbList)
{
    var childs = dbList.Where(x => x.parentID == step.id);
    if (!childs.Any())
        return;
    step.childs = childs.Select(x => new Steps { id = x.id, name = x.name }).ToList();
    step.childs.ForEach(x => Sample(x, dbList));
}
