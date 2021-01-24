public class MyObjectEqualityComparer : IEqualityComparer<MyObject>
{
    public bool Equals(MyObject x, MyObject y)
    {
        return x.Location.Equals(y.Location) && x.Name.Equals(y.Name);
    }
    public int GetHashCode(MyObject obj)
    {
        long stackedHashCode = obj.Location.GetHashCode() + obj.Name.GetHashCode();
        return (int)(stackedHashCode % int.MaxValue);
    }
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.except?view=netframework-4.8#System_Linq_Enumerable_Except__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_IEnumerable___0__System_Collections_Generic_IEqualityComparer___0__
  [2]: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1?view=netframework-4.8
