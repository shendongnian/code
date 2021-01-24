public interface IAllOurInfo
{
    string[] Errors { get; }
}
public interface IAllOurInfo<T> : IAllOurInfo
{
    T TheData { get; }
}
public struct AllOurStringInfo : IAllOurInfo<string>
{
    public string[] Errors { get; private set; }
    public string TheData { get; private set; }
    public AllOurStringInfo(string[] errors, string theData)  : this()
    {
        Errors = errors;
        TheData = theData;
    }
}
public struct AllOurStringArrayInfo : IAllOurInfo<string[]>
{
    public string[] Errors { get; private set; }
    public string[] TheData { get; private set; }
    public AllOurStringArrayInfo(string[] errors, string[] theData) : this()
    {
        Errors = errors;
        TheData = theData;
    }
}
public IAllOurInfo EvaluateData(dynamic dData)
{
    // Figure out the type of data, call the right class
    // I am just giving an example here 
    if (dData.GetType() == typeof(string))
    {
        return new AllOurStringInfo(new[] { "Hello" }, "Hello");
    }
    // have no idea what I was given, return null or throw
    return null;
}
 Of course, you would still need to cast to the type expected.
