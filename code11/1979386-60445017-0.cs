csharp
class Program
{
    public static void Main()
    {
        var all = new List<People> { new People { Id = 1, Name = "andy1", }, new People { Id = 2, Name = "andy2", }, new People { Id = 3, Name = "andy3", }, new People { Id = 4, Name = "andy4", }, };
        var someOfThem = new List<People> { new People { Id = 1, Name = null, }, new People { Id = 2, Name = null, } };
        var test = all.Intersect(someOfThem, new PeopleIdComparer()).ToList();
        foreach (var item in test)
            Console.WriteLine("{0}={1}", item.Id, item.Name);
    }
}
public class PeopleIdComparer : IEqualityComparer<People>
{
    public bool Equals(People x, People y)
    {
        return x.Id == y.Id;
    }
    public int GetHashCode(People obj)
    {
        return HashCode.Combine(obj.Id);
    }
}
public class People
{
    public int Id
    {
        get;
        set;
    }
    public string Name
    {
        get;
        set;
    }
}
