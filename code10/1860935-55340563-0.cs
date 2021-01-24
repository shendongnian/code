csharp
public static IEnumerable<string> OrderedMales(IEnumerable<Person> persons)
{
    return persons.Where(
        p => p.Sex == Gender.Male).OrderBy(p => p.Age);
}
