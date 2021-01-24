 c#
public void M()
{
    IEnumerable<string> enumerable = Enumerable.Distinct(Enumerable.Select(Enumerable.Where(items, new Func<string, bool>(<M>b__2_0)), new Func<string, string>(<M>b__2_1)));
}
public void N()
{
    IEnumerable<string> enumerable = Enumerable.Distinct(Enumerable.Select(Enumerable.Where(items, new Func<string, bool>(<N>b__3_0)), new Func<string, string>(<N>b__3_1)));
}
They use different compiler-generated methods, but the implementations are the same:
 c#
[CompilerGenerated]
private bool <M>b__2_0(string w)
{
    return w.Length >= length;
}
[CompilerGenerated]
private string <M>b__2_1(string w)
{
    return w.Substring(0, length);
}
[CompilerGenerated]
private bool <N>b__3_0(string a)
{
    return a.Length >= length;
}
[CompilerGenerated]
private string <N>b__3_1(string a)
{
    return a.Substring(0, length);
}
So: we can conclude yes, they're the same.
