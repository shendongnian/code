var parentWithoutNameOne = new Parent
{
    Childs = parent.Childs
                    .Select(o => new Child()
                    {
                        GrandChilds = o.GrandChilds.Select(p => new GrandChild
                        {
                            GreatGrandChilds = p.GreatGrandChilds
                                                .Where(l => l.Name != "Name One")
                                                .ToList()
                        }).ToList()
                    }).ToList()
};
And here are the definitions of the class i'm using:
public class Parent
{
    public List<Child> Childs { get; set; }
}
public class Child
{
    public List<GrandChild> GrandChilds { get; set; }
}
public class GrandChild
{
    public List<GreatGrandChild> GreatGrandChilds { get; set; }
}
public class GreatGrandChild
{
    public string Name { get; set; }
}
