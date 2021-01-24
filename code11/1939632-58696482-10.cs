    public class PointsDictionary : IEnumerable<Point>
    {
      private readonly Dictionary<int, Point> Items = new Dictionary<int, Point>();
      private int NextID;
      public Point this[int index]
      {
        get
        {
          return Items.ContainsKey(index) ? Items[index] : null;
        }
      }
      public Dictionary<int, Point>.KeyCollection IDs
      {
        get
        {
          return Items.Keys;
        }
      }
      public Dictionary<int, Point>.ValueCollection Points
      {
        get
        {
          return Items.Values;
        }
      }
      public int Add(Point point)
      {
        int index = NextID++;
        Items.Add(index, point);
        return index;
      }
      ...
    }
