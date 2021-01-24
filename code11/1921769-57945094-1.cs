csharp
public abstract class Factory<T>
{
    public T Create(DataRow row);
}
Now the next thing you would do is creating specific instances for each type you want to create, e.g.
csharp
public sealed class AirlineModelFactory : Factory<AirlineModel>
{
    public override AirlineModel Create(DataRow row)
    {
        return new AirlineModel
        {
            Code = row["code"].ToString(),
            AirlineName = row["name"].ToString()
        };
    }
}
Now the boilerplate code is this:
csharp
public void GetData<T>(List<T> list, DataTable table, Factory<T> factory)
where T : class, new()
{
    foreach (DataRow row in table.Rows)
    {
        list.Add(factory.Create(row));
    }            
}
and you may call it as
csharp
GetData(AirlineList, table, new AirlineModelFactory());
GetData(AirpoirtList, table, new AirportModelFactory());
// etc.
although, arguably, you may want to keep your factory instances around (or even inject them for inversion of control) to avoid the `new`.
However, as you will notice, you still need to create `N` classes / methods for `N` types.
To automate things a bit more, you could introduce a "generic" base class to your factories, e.g.
public abstract class GenericFactory
{
    public abstract object CreateObject(DataRow row);
}
and then implement
public abstract class Factory<T> : GenericFactory
{
    public override object CreateObject(DataRow row) => Create(row);
    // ...
}
With this, you could think of a lookup dictionary `Dictionary<Type, GenericFactory>`. By picking the right type and then casting to the right `T`, you get your correct instance. This is, however, a service locator pattern - a code smell, because a missing registration in the dictionary leads to an error at runtime - but depending on your needs, it could still be of help.
