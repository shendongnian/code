csharp
var source = new SourceContext();
var destination = new DestinationContext();
var tables = new List<(string, Type)>
{
    ("Table A", typeof(TableA)),
    ("Table B", typeof(TableB))
};
var executeMethodInfo = GetType().GetMethod("Execute");
foreach (var (displayName, entityType) in tables)
{
    executeMethodInfo.MakeGenericMethod(entityType)
        .Invoke(this, new object[] { displayName, source, destination });
}
The generic `Execute` method would look like this:
csharp
public void Execute<T>(string displayName, SourceContext source, DestinationContext destination)
    where T : class
{
    Console.WriteLine($"Processing {displayName}");
    destination.RemoveRange(destination.Set<T>());
    destination.SaveChanges();
    destination.AddRange(source.Set<T>().AsNoTracking().ToList());
    destination.SaveChanges();
}
