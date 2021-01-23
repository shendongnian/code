    public class MyClass
{
    ...
    public Foo DoSomething(string arg)
    {
        try
        {
           //do something
        }
        catch(Exception e)
        {
           log.error(string.format("{0} Arguements: {1}", e.Tostring(), arg);
        }
    }
