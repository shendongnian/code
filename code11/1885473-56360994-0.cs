class MetaData
{
  public int Id {get;set;}
  public string CLRType {get;set;}
  public string Value {get;set;}
  public int PersonId {get;set;}
  public Person Person {get;set;}
  public int CarId {get;set;}
  public Car Car {get;set;}
  public int BuildingId {get;set;}
  public Person Building {get;set;}
}
Or keep it loosely coupled and do the joins by hand
class Car
{
  public int Id {get;set;}
  public string Make {get;set;}
}
// not mapped in the database, just used for display purposes
class CarViewModel 
{
  public int Id {get;set;}
  public string Make {get;set;}
}
var carIds = new [] { 1, 2, 3 };
// we use 2 contexts here so we can query both tables at the same time.
// otherwise Task.WhenAll(...) would throw an exception.
// you should also disable change tracking to improve speed.
var carsTask = context1.Cars
    .Where(c => carIds.Contains(c.Id))
    .ToListAsync();
var metadataTask = context2.Metadata
    .Where(m => carIds.Contains(m.Key) && m.Type == "Car")
    .GroupBy(m => m.Key)
    .ToDictionaryAsync(g => g.Key, g => g.ToList());
await Task.WhenAll(carsTask, metadataTask).ConfigureAwait(false);
var cars = carsTask.Result
    .Select(c => new CarViewModel
    {
        Id = c.Id,
        Make = c.Make,
        Metadata = metadataTask.Result.TryGetValue(c.Id, out var m) ? m : Array.Empty<Metadata>(),
    })
    .ToList();
Or have separate tables for the metadata
abstract class MetaData
{
  public int Id {get;set;}
  public string CLRType {get;set;}
  public string Value {get;set;}
}
class CarMetaData : MetaData
{
  public int CarId {get;set;}
  public Car Car {get;set;}
}
class Car
{
  public int Id {get;set;}
  public string Make {get;set;}
  public ICollection<CarMetaData> MetaData {get;set;}
}
Which version suits you best is up to your and your specific business needs.
