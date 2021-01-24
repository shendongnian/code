    public class Site {
      public Site() { }
      public string RouteId;
      public Decimal StartMilepost;
      public Decimal EndMilepost;
      public override string ToString() => $"{RouteId} {StartMilepost}..{EndMilepost}";
    }
