public class Proxy<T>
{
    public Proxy(T obj)
    {
        this.Reference = obj;
    }
    public T Reference { get; set; }
}
This way you can create a list of proxies:
var test1 = new Proxy<TestObject>(new TestObject { test = 1 });
var test2 = new Proxy<TestObject>(new TestObject { test = 2 });
var list = new List<Proxy<TestObject>>() { test1, test2 };
And later you can reassign the values as you wish:
public static void Test2(List<Proxy<TestObject>> list)
{
    list[0].Reference = test3;
    list[1].Reference = test4;
}
Now after the method has returned, `test1` and `test2` will (indirectly) reference the new objects.
Having said that, I'd say that I think it's cumbersome and hacky - I'd rather change the actual objects than references to them (the proxies do just that).
