    using System;
    class ReplaceAContentsWithCommaSeparatedChars
    {
        static readonly string acroStartTag = "<a>";
        static readonly string acroEndTag = "</a>";
        static void Main(string[] args)
        {
            string s = "Alpha <a>Beta</a> Gamma <a>Delta</a>";
            while (true)
            {
                int start = s.IndexOf(acroStartTag);
                if (start < 0)
                    break;
                int end = s.IndexOf("</a>", start + acroStartTag.Length);
                if (end < 0)
                    end = s.Length;
                string contents = s.Substring(start + acroStartTag.Length, end - start - acroStartTag.Length);
                string[] chars = Array.ConvertAll<char, string>(contents.ToCharArray(), c => c.ToString());
                s = s.Substring(0, start)
                    + string.Join(",", chars)
                    + s.Substring(end + acroEndTag.Length);
            }
            Console.WriteLine(s);
        }
    }
