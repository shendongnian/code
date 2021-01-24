c#
public class ReportComparer : IEqualityComparer<Report>
{
    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;
        var y = obj as Report;
        if (y == null)
            return false;
        return
            this.Name == y.Name &&
            this.Long == y.Long &&
            this.Lat == y.Lat;
    }
    public int GetHashCode(Report obj)
    {
        return (this.Name + this.Long + this.Lat).GetHashCode();
    }
}
And then instantiate your `HashSet` with it:
HashSet<Report> reports = new HashSet<Report>(new ReportComparer())
Documentation:
[MSDN EqualityComparer][1]
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.equalitycomparer-1?view=netframework-4.8#examples
