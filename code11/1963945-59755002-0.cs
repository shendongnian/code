 c#
public List<Bar> Bars { get; } = new List<Bar>();
(optionally with some `[XmlElement]`, `[XmlArray]` or `[XmlArrayItem]` etc attributes).
If that *doesn't* work; please post a minimal example that shows it not working.
Here's an example of it working:
 c#
class Program
{
    static void Main()
    {
        var foo = new Foo {
            Bars = {
                    new Bar { X = 42 },
                    new Bar { X = 12 },
                    new Bar { X = 6 },
                }
        };
        var ser = new XmlSerializer(foo.GetType());
        var sw = new StringWriter();
        ser.Serialize(sw, foo);
        var xml = sw.ToString();
        Console.WriteLine(xml);
        var sr = new StringReader(xml);
        var clone = (Foo)ser.Deserialize(sr);
        foreach (var bar in clone.Bars)
            Console.WriteLine(bar.X);
    }
}
public class Foo
{
    public List<Bar> Bars { get; } = new List<Bar>();
}
public class Bar
{
    public int X { get; set; }
}
