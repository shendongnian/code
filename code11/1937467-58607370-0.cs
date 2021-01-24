var searchName = Console.ReadLine();
var results = PeopleList
    .Where(x => x.Name.Contains(searchName, StringComparison.InvariantCultureIgnoreCase))
    .ToList();
if (results.Any())
{
    foreach (var person in results)
    {
        Console.WriteLine($"Found: {person.Name}");
    }
}
else
{
    Console.WriteLine("Name not found");
}
----
Note: Your class should be called `Person` since it represents data about a single person, not about multiple people.
