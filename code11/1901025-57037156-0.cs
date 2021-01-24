cs
public static class IHtmlContentExtensions
{
    public static string GetString(this Microsoft.AspNetCore.Html.IHtmlContent content)
    {
        using (var writer = new System.IO.StringWriter())
        {        
            content.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
            return writer.ToString();
        }
    }
}
Then from your code, you can just call
cs
TagBuilder myTag = // ...
string tagAsText = myTag.GetString();
