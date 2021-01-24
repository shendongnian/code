public interface IName
{
    string Name {get;set;}
}
public class Genre: IName
{
    public string Name {get;set;}
}
And use:
where T : IName, new()
Now you could do:
var t = new T();
t.Name = name;
