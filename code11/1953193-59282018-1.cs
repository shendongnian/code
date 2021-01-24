var allPeople = people1.Union(people2, new PersonComparer());
public class PersonComparer : IEqualityComparer<Person>
{
  public bool Equals(Person x, Person y)
  {
    // ommited null checks etc
    return x.Id == y.Id;
  }
  public int GetHashCode(Person obj)
  {
    // ommited null checks etc
    obj.Id.GetHashCode()
  }
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.union?view=netframework-4.8#System_Linq_Enumerable_Union__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_IEnumerable___0__System_Collections_Generic_IEqualityComparer___0__
