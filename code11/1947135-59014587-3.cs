public interface IName
{
    string Name {get;set;}
}
public class Genre: IName
{
    public string Name {get;set;}
}
public class Actor: IName
{
    public string Name {get;set;}
}
And use:
where T : IName, new()
Now you could do:
var t = new T();
t.Name = name;
## Func
Another option is to send a Func, 
Change signature to:
ConvertStringToList<T>(string genreList, Func<string, T> createFunc)
Instead of `new T()`, use `createFunc(name)`:
string name = str.Trim();
genres.Add(createFunc(name));
Usage:
ConvertStringToList<Genre>(test2, name => new Genre{Name = name});
PS. No need for the `new()` constraint when using this method
