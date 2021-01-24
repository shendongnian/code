    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication117
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                string input = File.ReadAllText(FILENAME);
                string pattern = @"(?'xml'\<\?.*)--MIMEBoundary";
                Match match = Regex.Match(input,pattern,RegexOptions.Singleline);
                string xml = match.Groups["xml"].Value.Trim();
                string pattern1 = @"\<[?/]?((\s*\w+\s*:\s*\w+)|(\s*\w+))";
                xml = Regex.Replace(xml, pattern1, ReplaceSpaces);
                string pattern2 = @"\w+\s*:\s*\w+\s*=";
                xml = Regex.Replace(xml, pattern2, ReplaceSpaces); //remove spaces in namespaces
                XDocument doc = XDocument.Parse(xml);
            }
            static string ReplaceSpaces(Match match)
            {
                string input = match.Value;
                string pattern = @"\s*(?'name1'\w+)\s*(?'colon':)*\s*(?'name2'\w*)";
                string output = Regex.Replace(input, pattern, "${name1}${colon}${name2}");
                return output;
            }
        }
        public class Player
        {
        }
    }
