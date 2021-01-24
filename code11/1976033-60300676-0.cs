csharp
public class PointOnChart : IEquatable<PointOnChart> {
    public string Timestamp { get; set; }
    public double Value1 { get; set; }
    public double Value2 { get; set; }
    public double Value3 { get; set; }
    public override Int32 GetHashCode() => Timestamp.GetHashCode() ^ Value1.GetHashCode() ^ Value2.GetHashCode() ^ Value3.GetHashCode();
    public override Boolean Equals(Object obj) => Equals(obj as PointOnChart);
    public Boolean Equals(PointOnChart other) => other != null && other.Timestamp == Timestamp && other.Value1.Equals(Value1) && other.Value2.Equals(Value2) && other.Value3.Equals(Value3);
}
That'll give you all the comparing you'll need.
Will also make it easier to implement an `IEqualityComparer` or `IEqualityComparer<T>` if you need it later on.
