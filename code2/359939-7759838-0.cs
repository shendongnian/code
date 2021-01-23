      static Dictionary<string, string> GetProduct(string name, string html)
        {
            Dictionary<string, string> output = new Dictionary<string, string>();
            string clfr = @"[\r\n]*[^\r\n]+";
            string pattern = string.Format(@"href='([^']+)'>{0}</a>.*{1}{1}[\r\n]*([^\$][^\r\n]+)", name, clfr);
            Match products = Regex.Match(html, pattern, RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
            if(products.Success) {
                GroupCollection details = products.Groups;
                output.Add("Name", name);
                output.Add("Link", details[1].Value);
                output.Add("Price", details[2].Value.Trim());
                return output;
            }
            return output;
        }
