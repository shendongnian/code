csharp
public class Meeting
{
    [Key] 
    public string Id { get; set; }
    public string CreatorId { get; set; }
    public string[] Members { get; set; }
}
and now it works.
  [1]: https://www.npgsql.org/efcore/mapping/array.html
