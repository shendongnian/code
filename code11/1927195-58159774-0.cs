 c#
var list = new List<(int id, string name)>();
list.Add((1, "hello"));
(Although technically these aren't objects until boxed, but: it'll do the job)
In reality: just declare the class that you clearly want here. It'll save you a lot of pain:
 c#
class Something {
    public int Id {get;set;}
    public string Name {get;set;}
}
and use a `List<Something>`
