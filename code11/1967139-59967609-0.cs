    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Diagnostics;
    
    namespace htmlRender
    {
        class Program
        {
            const string oldHTML = "<h1>Title {34}</h1><p>Paragraph {4}</p><div> Div here {14}</div>";
            static Dictionary<string, string> dict = new Dictionary<string, string>()
                {
                    {  "4", "dict value for 4" },
                    { "14", "dict value for 14"},
                    { "34", "dict value for 34"}
                };
    
            static void Main(string[] args)
            {
                Stopwatch sw = Stopwatch.StartNew();
                Regex rx = new Regex(@"{\d+}");
    
                string newHTMLRegex = rx.Replace(oldHTML, new MatchEvaluator(ReplaceText));
                sw.Stop();
                //Console.WriteLine(newHTMLRegex);
                Console.WriteLine("Execution time regex took " + sw.ElapsedTicks + " ticks.");
    
    
                sw = Stopwatch.StartNew();
                var sb = new StringBuilder();
                var str = oldHTML.Split(new char[] { '{', '}' });
                if (str.Length > 0)
                {
                    for (int i = 0; i < str.Length; i += 2)
                    {
                        sb.Append(str[i]);
                        if (str.Length > i + 1)
                            sb.Append(dict[str[i + 1]]);
                    }
                }
                string newHTMLSplit = sb.ToString();
                sw.Stop();
                //Console.WriteLine(newHTMLSplit);
                Console.WriteLine("Execution time split took " + sw.ElapsedTicks + " ticks.");
    
                Console.ReadKey();
            }
    
            static string ReplaceText(Match m)
            {
                string x = m.ToString().Replace("{", "").Replace("}", "");
    
                return dict[x];
            }
        }
    }
