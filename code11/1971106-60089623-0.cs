 c#
public class Rootobject
{
    public string key1 { get; set; }
    public InnerObject key2 { get; set; }
}
public class InnerObject 
{
    public Dictionary<string, ObjectTheThird> items { get; }
        = new Dictionary<string, ObjectTheThird>();
}
public class InnerObject 
{
    public int pageid { get; set; }
    public string name { get; set; }
}
and use the APIs on `Dictionary<,>` to look at the items. Or you just want the first:
 c#
var name = obj.key2.items.First().Value.name;
