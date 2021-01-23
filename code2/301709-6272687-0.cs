    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    static class Program
    {
      static void Main ()
      {
        string html = "<p><a href=\"docs/123.pdf\">33</a></p>"; // read the whole html file into this string.
        StringBuilder newHtml = new StringBuilder (html);
        Regex r = new Regex (@"\<a href=\""([^\""]+)\"">([^<]+)"); // 1st capture for the replacement and 2nd for the find
        foreach (var match in r.Matches(html).Cast<Match>().OrderByDescending(m => m.Index))
        {
           string text = match.Groups[2].Value;
           string newHref = DBTranslate (text);
           newHtml.Remove (match.Groups[1].Index, match.Groups[1].Length);
           newHtml.Insert (match.Groups[1].Index, newHref);
        }
    
        Console.WriteLine (newHtml);
      }
    
      static string DBTranslate(string s)
      {
        return "junk_" + s;
      }
    }
