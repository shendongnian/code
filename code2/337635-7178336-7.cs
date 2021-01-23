using System.Text.RegularExpressions;
namespace ConsoleApplication1
{
    public static class StringExtensions
    {
        public static string StripLeadingWhitespace(this string s)
        {
            Regex r = new Regex(@"^\s+", RegexOptions.Multiline);
            return r.Replace(s, string.Empty);
        }
    }
}
