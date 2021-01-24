class Program
{
    static void Main(string[] args)
    {
        var p = new Person
        {
            Professions = new List<Profession>
            {
                new Profession("Joker"),
                new Profession("Smoker"),
                new Profession("Midnight toker")
            }
        };
        var accessor = ObjectAccessor.Create(p);
        var professions = accessor[nameof(Person.Professions)];
        if (professions is IEnumerable)
        {
            foreach (var profession in (IEnumerable)professions)
            {
                Console.WriteLine(profession);
            }
        }
    }
}
class Person
{
    public List<Profession> Professions { get; set; }
}
class Profession
{
    public string Name { get; set; }
    public Profession( string name)
    {
        Name = name;
    }
    public override string ToString()
    {
        return Name;
    }
}
