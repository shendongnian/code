        static string stripHTMLTags1(string html)
        {
            string pattern = @"<[^>]+>";
            var expression = new Regex(pattern);
            return expression.Replace(html, String.Empty);
        }
        static string stripHTMLTags2(string html)
        {
            // From http://gskinner.com/RegExr/
            string pattern = @"</?\w+((\s+\w+(\s*=\s*(?:"".*?""|'.*?'|[^'"">\s]+))?)+\s*|\s*)/?>";
            var expression = new Regex(pattern);
            return expression.Replace(html, String.Empty);
        }
