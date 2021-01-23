        static string[] pats3 = { "é", "É", "á", "Á", "í", "Í", "ó", "Ó", "ú", "Ú" };
        static string[] repl3 = { "e", "E", "a", "A", "i", "I", "o", "O", "u", "U" };
        static Dictionary<string, string> _var = null;
        static Dictionary<string, string> dict
        {
            get
            {
                if (_var == null)
                {
                    _var = pats3.Zip(repl3, (k, v) => new { Key = k, Value = v }).ToDictionary(o => o.Key, o => o.Value);
                }
                return _var;
            }
        }
        private static string RemoveAccent(string text)
        {
            // using Zip as a shortcut, otherwise setup dictionary differently as others have shown
            //var dict = pats3.Zip(repl3, (k, v) => new { Key = k, Value = v }).ToDictionary(o => o.Key, o => o.Value);
            //string input = "åÅæÆäÄöÖøØèÈàÀìÌõÕïÏ";
            string pattern = String.Join("|", dict.Keys.Select(k => k)); // use ToArray() for .NET 3.5
            string result = Regex.Replace(text, pattern, m => dict[m.Value]);
            //Console.WriteLine("Pattern: " + pattern);
            //Console.WriteLine("Input: " + text);
            //Console.WriteLine("Result: " + result);
            return result;
        }
