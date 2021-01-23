        protected void Page_Load(object sender, EventArgs e)
        {
            string input = @"My link: [url='http://www.something.com'][b]Some text[/b][/url] is awesome. Jazz hands activate!!";
            string result = Parse(input);
        }
    //Result: My link: <a href="http://www.something.com"><b>Some text</b></a> is awesome. Jazz hands activate!!
    
    
        private static string Parse(string input)
        {
            string regex = @"\[([^=]+)[=\x22']*(\S*?)['\x22]*\](.+?)\[/(\1)\]";
            MatchCollection matches = new Regex(regex).Matches(input);
            for (int i = 0; i < matches.Count; i++)
            {
                var tag = matches[i].Groups[1].Value;
                var optionalValue = matches[i].Groups[2].Value;
                var content = matches[i].Groups[3].Value;
    
                if (Regex.IsMatch(content, regex)) 
                {
                    content = Parse(content);
                }
    
                content = HandleTags(content, optionalValue, tag);
    
                input = input.Replace(matches[i].Groups[0].Value, content);
            }
    
            return input;
        }
    
        private static string HandleTags(string content, string optionalValue, string tag)
        {
            switch (tag.ToLower())
            {
                case "url":
                    return string.Format("<a href=\"{0}\">{1}</a>", optionalValue, content);
                case "b":
                    return string.Format("<b>{0}</b>", content);
                default:
                    return string.Empty;
            }
        }
