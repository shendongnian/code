public class Foo
{
    public int Id { get; set; }
    public string Bar { get; set; }
    internal string SetBar(string v) => Bar = v;
}
public static void Main(string[] args)
{
    var items = new List<Foo>{ new Foo { Id = 1, Bar = "Bar" } };
    items.FirstOrDefault(i => i.Id == 1)?.SetBar("Baz");   
}
---
# set_Bar
For the record, the compiler will reject an attempt to call set_Bar` directly
items.FirstOrDefault(i => i.Id == 1)?.set_Bar("Baz");
// 'Program.Foo.Bar.set': cannot explicitly call operator or accessor (CS0571)
