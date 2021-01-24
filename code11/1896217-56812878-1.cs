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
## EDIT
As @Servy correctly mentioned, I explained why the original code won't work, but I didn't explain how the original problem can be solved.
Here is how:
c#
// define a separate interface for non-typed invocation
public interface IRule
{
    object ExecuteGeneric();
}
public interface IRule<T> : IRule 
{
    T Execute();
}
// every rule implements both typed and non-typed invocation interface
public class Rule : IRule<int>
{
    public int Execute()
    {
        return 10;
    }
    object IRule.ExecuteGeneric()
    {
        return Execute();
    }
}
//.....
IRule<int> rule = new Rule();
IRule genericRule = rule;
// perform non-typed invocation on rules of any T
var genericResult = genericRule.ExecuteGeneric();
