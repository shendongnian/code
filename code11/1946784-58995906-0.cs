csharp
public static IEnumerable<T> SelectChilds<T>(this T source, Func<T, IEnumerable<T>> func)
{
    yield return source;
    foreach (T element in func(source) ?? Enumerable.Empty<T>())
    {
        var subs = element.SelectChilds(func);
        foreach (T sub in subs)
        {
            yield return sub;
        }
    }
}
Creation of the testdata and the extension in use to return the flat structure. After that a simple `Where` filters out all tasks.
csharp
var testdata = new Project(new Random(4));
var tasks = testdata.SelectChilds(x => x.children).Where(x => x.type == "task").ToList();
The class to test containing a list of its own type. Constructor is setup to make some testdata.
csharp
public class Project
{
    public Guid id { get; set; } = Guid.NewGuid();
    public string type { get; set; }
    public List<Project> children { get; set; } = new List<Project>();
    public Project(Random rng)
    {
        var count = rng.Next(3);
        type = count == 0 ? "task" : "collection";
        for (var i = 0; i < count; i++)
        {
            children.Add(new Project(rng));
        }
    }
}
