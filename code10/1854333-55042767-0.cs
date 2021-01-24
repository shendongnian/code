csharp
public class Event
{
    [PrimaryKey]
    public int Id { get; set; }
// Need the foreign key here
    [ForeignKey(typeof(ScoutData))]
    public int ScoutDataId { get; set; }
    public string startDate { get; set; }
    public string endDate { get; set; }
    public string eventName { get; set; }
    public bool isCurrentEvent { get; set; }
    public Event()
    {
    }
    public Event(string start, string end, string name, int id, bool isCurrent)
    {
        startDate = start;
        endDate = end;
        eventName = name;
        ID = id;
        isCurrentEvent = isCurrent;
    }
}
public class ScoutData
{
    [PrimaryKey]
    public int Id { get; set; } 
// I don't know what relationship you are looking for but this is one to one:
    [OneToOne(CascadeOperations = CascadeOperation.All)]
    public Event Event { get; set; }  
    public ScoutData()
    {
    }
    // Some public properties, including a public Event from the other class
}
Also if you are using async then use the async version [here][2] 
  [1]: https://www.nuget.org/packages/SQLiteNetExtensions/
  [2]: https://www.nuget.org/packages/SQLiteNetExtensions.Async/
