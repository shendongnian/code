public enum Rank
{
    SFC = 1, SSG, SGT
}
public class Person
{
    public Rank Rank { get; set; }
    public string Name { get; set; }
}
static void Main(string[] args)
{
    var persons = new List<Person>
    {
        new Person{ Name = "Aaaa", Rank = Rank.SFC },
        new Person{ Name = "Bbbb", Rank = Rank.SFC },
        new Person{ Name = "Aaaa", Rank = Rank.SSG }
    };
    foreach (var person in persons.OrderBy(p => p.Rank).ThenBy(p => p.Name))
    {
        Console.WriteLine("{0} {1}", person.Rank, person.Name);
    }
}
