C#
void Main()
{
	var snapshot = ((List<Snapshot>)snapshotService.GetSnapshot())
   .GroupBy(a => new
   {
	   a.SIId,
	   a.WarehouseId,
	   a.Treatment,
	   a.UnitOfMeasure
   })
   .Select(a => new Snapshot
	   {
		   SIId = a.Key.SIId,
		   WarehouseId = a.Key.WarehouseId,
		   Treatment = a.Key.Treatment,
		   UnitOfMeasure = a.Key.UnitOfMeasure,
		   TotalAmount = a.Sum(sum => sum.TotalAmount),
		   Available = a.Sum(sum => sum.Available),
		   Unavailable = a.Sum(sum => sum.Unavailable)
	  }).ToList();
	  
	  snapshot.Dump();	  
}
public class Snapshot
{
	public int SIId { get; set; }
	public int WarehouseId {get;set;}
	public int Treatment { get; set; }
	public int UnitOfMeasure { get; set; }
	public int TotalAmount { get; set; }
	public int Available { get; set; }
	public int Unavailable { get; set; }
}
public static class snapshotService
{
	public static object GetSnapshot()
	{
		string x = "[{\"SIId\":1,\"WareHouseId\":1,\"Treatment\":1,\"UnitOfMeasure\":1,\"TotalAmount\":1,\"Available\":1,\"Unavailable\":1},{\"SIId\":1,\"WareHouseId\":1,\"Treatment\":1,\"UnitOfMeasure\":1,\"TotalAmount\":2,\"Available\":2,\"Unavailable\" :2}]";
		return JsonConvert.DeserializeObject<List<Snapshot>>(x);
	}
}
the result came back:
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/c2GMI.png
