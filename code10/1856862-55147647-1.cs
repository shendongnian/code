 c#
Bank b = new Bank("NatWest", "London");
Console.WriteLine(b);
Now; the system doesn't automatically know what you want to write about the `Bank`, but everything that subclasses `object` has a `public virtual string ToString()` method, **for creating a text representation of a type**, so: this is what gets called. The default implementation of `ToString()` is to output the type name, but if you want to do something more interesting: *tell it what you want*.
I would suggest:
 c#
public override string ToString()
{
    return Getname();
}
You can do something similar with `Customer` to tell it what the default output would be for that.
Alternatively: just be explicit *in your output code*, i.e.
 c#
Console.WriteLine(b.Getname());
Finally, you might want to consider properties instead of methods like `Getname`, for example (using modern C# syntax):
 c#
class Bank
{
    public string Name { get; }
    public string Location { get; }
    public Bank(string name, string location)
    {
        Name = name;
        Location = location;
    }
    public override string ToString() => Name;
}
