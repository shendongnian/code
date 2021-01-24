C#
class Program
{
  static void Main( string[] args )
  {
    IEnumerable<Item> items = Enumerable.Empty<Item>();
    ( Age Age, Item[] Items )[] partitioned =
      items
      .Select( item => ComputeAge(item) )
      .GroupBy( x => x.Age )
      .Select( g => (
        Key    : g.Key ,
        Values : g.Select( x => x.Item )
                  .ToArray()
      ))
      .ToArray();
      ;
  }
  static ( Item Item, Age Age ) ComputeAge(Item item)
  {
    double days = (DateTime.Now - item.Received).TotalDays;
    Age age;
    // Does "week" means "with the last 7 days" or "within the current calendar week"
    // We'll assume it means within the last 7 days.
    if      ( days <  0.0 ) age = Age.Unknown;
    else if ( days <= 1.0 ) age = Age.Today;
    else if ( days <= 7.0 ) age = Age.Today;
    else                    age = Age.Earlier;
    return (item, age) ;
  }
}
public enum Age { Unknown = 0, Today = 1, ThisWeek = 2, Earlier = 3 }
class Item
{
  public string   Message  { get; set; }
  public string   Sender   { get; set; }
  public DateTime Received { get; set; }
}
