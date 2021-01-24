public class AAA
{
    public int Id { get; set; }
    public string ValueA { get; set; }
}
public class BBB
{
    public int UpdatedOrCreated { get; set; } = 2;
    public int Id { get; set; }
    public string ValueA { get; set; }
}
public class CustomList : List<BBB>
{
    public new void Add(BBB item)
    {
        item.UpdatedOrCreated = 3;
        base.Add(item);
    }
}
var varout = new CustomList
{
    new BBB
    {
        Id = 1,
        ValueA = "bang"
    }
};
