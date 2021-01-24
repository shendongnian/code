[CompilerGenerated]
private sealed class <>c__DisplayClass1_0
{
    public MyData test;
    internal void <SetBinding>b__0(object o, PropertyChangedEventArgs r)
    {
        test.Id++;
    }
}
...and replaces your anonymous function with a similar function of the generated class:
private static void SetBinding(Property p, MyData test)
{
    var a = new <>c__DisplayClass1_0();
    a.test = test;
    p.PropertyChanged += a.<SetBinding>b__0;
}
