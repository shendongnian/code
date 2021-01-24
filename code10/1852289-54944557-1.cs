public static class Extension
{
    public static bool DoStuff(this Class stuff)
    {
        return false;
    }
}
public class Class
{
    public bool DontCallMe()
    {
        return this.DoStuff();
    }
}
Class myClass = new Class();
myClass.DoStuff();
Obviously, that only works if you can change the code of your class (which I suppose you aren't able to)
If that method is marked as virutal, you could create a Wrapper-Class which overrides that method.
public static class Extension
{
    public static bool DoStuff(this Class stuff)
    {
        return false;
    }
}
public class Class : Base
{
    public override bool DontCallMe()
    {
        return this.DoStuff();
    }
}
public class Base
{
    public virtual bool DontCallMe()
    {
        return false;
    }
}
_____
Another approach would be to do what I described in this [this](https://stackoverflow.com/questions/54822112/two-namespaces-with-the-same-object-name/54822260#54822260) post.
