c#
public interface IRule <out T> 
{
    T Execute();
}
public class Rule : IRule<string> // T must be a reference type
{
    public string Execute()
    {
        return "10";
    }
}
//....
IRule<string> rule = new Rule();
var genericRule = (IRule<object>) rule;
