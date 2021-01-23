        public static class RazorConversor
    {
        public static void ConvertAll(string directory)
        {
            string[] array = Directory.GetFiles(directory, "*.aspx", SearchOption.AllDirectories).Concat(
                             Directory.GetFiles(directory, "*.ascx", SearchOption.AllDirectories)).ToArray();
            foreach (var fileName in array)
            {
                string aspxCode = File.ReadAllText(fileName);
                string razorCode = ConvertToRazor(aspxCode);
                File.WriteAllText(fileName, razorCode); //rename manually to update .csproj & source control
            }
        }
        
        static readonly string[] DefaultNamespaces = new string[]
        {
            "System.Web.Helpers", 
            "System.Web.Mvc",
            "System.Web.Mvc.Ajax",
            "System.Web.Mvc.Html",
            "System.Web.Routing",
            "System.Web.WebPages",
        };
        public static string ConvertToRazor(string aspxCode)
        {
            return ConvertToRazor(aspxCode, DefaultNamespaces); 
        }
        public static string ConvertToRazor(string aspxCode, string[] defaultNamespaces)
        {
            //namespaces
            string text2 = Regex.Replace(aspxCode, @"<%@\s+Import Namespace=""(?<ns>.*?)""\s+%>",
                m => defaultNamespaces.Contains(m.Groups["ns"].Value) ? null : "@using " + m.Groups["ns"].Value);
            
            //headers
            string text3 = Regex.Replace(text2, @"<%@\s(?<dir>.*?)%>", m =>  "@{ " + m.Groups["dir"].Value + "}"); // Preserves headers
            //expressions 
            string text4 = Regex.Replace(text3, @"<%[=:](?<expr>.*?)%>", m =>
            {
                string expr = m.Groups["expr"].Value.Trim();
                string cleanExpr = Regex.Replace(expr, @"(""(\\""|[^""])*"")|(@""([^""]|"""")*"")|(\([^\(\)]*(((?'Open'\()[^\(\)]*)+((?'Close-Open'\))[^\(\)]*)+)*\))", m2 => "");
                return cleanExpr.Contains(' ') ? "@(" + expr + ")" : "@" + expr;
            }, RegexOptions.Singleline);
            //code blocks
            string text5 = Regex.Replace(text4, @"<%(?<code>.*?)%>", m =>
            {
                string code = m.Groups["code"].Value.Trim();
                Dictionary<string, string> stringLiterals = new Dictionary<string,string>();
                code = Regex.Replace(code, @"(""(\\""|[^""])*"")|(@""([^""]|"""")*"")", m2 =>
                {
                    string key = "<$" + stringLiterals.Count + "$>";
                    stringLiterals.Add(key, m2.Value);
                    return key;
                }); 
                string result = Regex.Replace(code, 
                    @"((?<blockHeader>(else|(for|switch|foreach|using|while|if)\s*\([^\(\)]*(((?'Open'\()[^\(\)]*)+((?'Close-Open'\))[^\(\)]*)+)*\))\s*)" + 
                    @"((?<fullBlock>{[^{}]*(((?'OpenCurly'{)[^{}]*)+((?'CloseCurly-OpenCurly'})[^{}]*)+)*})|(?<openblock>{.*))|" + 
                    @"(?<text>((?!({|}|\s)(for|switch|foreach|using|while|if|else)(\s|{|\()).)+))",
                    m2 =>
                    {
                        if(m2.Value.Trim().Length == 0 || m2.Value.StartsWith("else")|| m2.Value.StartsWith("}"))
                            return m2.Value;
                        if(m2.Groups["text"].Success)
                            return "@{ " + m2.Value.Trim() + "}\r\n"; 
                        return "@" + m2.Value; 
                    }, RegexOptions.ExplicitCapture | RegexOptions.Singleline);
                result = Regex.Replace(result, @"<\$\d+\$>", 
                    m2 => stringLiterals[m2.Value]);
                return result;
            }, RegexOptions.Singleline);
 
            return text5; 
        }
    }
