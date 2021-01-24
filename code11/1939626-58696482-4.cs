public class PointsDictionary : IEnumerable<Point>
{
  private readonly Dictionary<int, Point> Items = new Dictionary<int, Point>();
  private int LastId;
  public Point this[int index]
  {
    if ( Items.ContainsKey(index) )
      return Items[index]
    else
      return null;
  }
  public int Add(Point point)
  {
    Items.Add(LastID++, point);
  }
  ...
}
