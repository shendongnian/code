c#
class DatesReport
{
	public int IdReport { get; set; }
    ... more properties
	public ICollection<Maquina> Maquinas { get; set; }
	public ICollection<Faltante> Faltantes { get; set; }
    ... etc.
}
And in the context a property...
c#
public DbSet<DatesReport> Reports { get; set; }
Now you can get the data you want by only one Where condition:
var report = context.Reports
    .Include(r => r.Maquinas)
    .Include(r => r.Faltantes)
    ... etc
    .Single(r => r.Id == id)
The serialized `report` will look different than the Json you have now, but the UI code should be able to handle that. Likewise, it should return a `DatesReport` object containing these collections. If it does, adding a new report gets very simple:
c#
context.Reports.Add(report);
context.SaveChanges();
Where `report` is the report object that enters the action method `MetodoRecibe` instead of the `datos` object. It will add the report and all contained collections in one go.
