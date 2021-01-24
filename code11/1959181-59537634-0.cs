csharp
public class HtmlEncodedString
{
    public string Value { get; }
    public HtmlEncodedString(string value) => 
        Value = HttpUtility.HtmlEncode(value);
    public static implicit operator string(HtmlEncodedString htmlEncodedString) => 
        htmlEncodedString.Value;
    public static implicit operator HtmlEncodedString(string value) =>
        new HtmlEncodedString(value);
}
That's of course only a sketch. If you're using ASP.NET Core, consider implementing [`IHtmlContent`](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.html.ihtmlcontent?view=aspnetcore-3.1). If you're allocating a lot of these, maybe making it a value type will decrease the pressure on the GC. Neverminding these details, you now can get reusability by just using this type instead of an attribute on a string.
csharp
public class Test
{
    public HtmlEncodedString Body { get; set; }
    public int Id { get; set; }
}
Because of the implicit operators, transition is seemless:
csharp
var test = new Test();
test.Body = "2 < 4";
string s = test.Body;
Console.WriteLine(s);
Console.WriteLine(test.Body);
> 2 &lt; 4
> 2 &lt; 4
