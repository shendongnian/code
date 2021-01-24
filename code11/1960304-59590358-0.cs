C#
public interface ISomething 
{
    void MethodToInvoke();
}
Then, instead of a list of objects, you'd have:   
C#
list<ISomething> list1 = ...
And you call the method defined in the interface:   
C# 
foreach(ISomething item in new Pjo().List1)
{
    item.MethodToInvoke();
}
