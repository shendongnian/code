C#
public class MyClass<T>
{
    private T svalue;
    private Func<MyClass<T>, T, bool> spredicate;
    private void Update(T nvalue)
    {
        if (spredicate(this, svalue))
            svalue = nvalue;
    }
    public MyClass(Func<MyClass<T>, T, bool> condition)
    {
        spredicate = condition;
    }
    public T Value
    {
        get { return svalue; }
        set { Update(value); }
    }
    public static void Example()
    {
        var myvar = new MyClass<int>((self, newval) => Math.Abs(newval - self.svalue) < 10);
    }
}
We could instead give the predicate a second `T` parameter instead of `MyClass<T>`, but then there would be confusion about which parameter is the old value and which is the new one. 
