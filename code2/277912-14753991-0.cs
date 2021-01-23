     public string ConvertLink(string input)
        {
            //Add http:// to link url
            Regex urlRx = new Regex(@"(?<url>(http(s?):[/][/]|www.)([a-z]|[A-Z]|[0-9]|[/.]|[~])*)", RegexOptions.IgnoreCase);
            MatchCollection matches = urlRx.Matches(input);
            foreach (Match match in matches)
            {
                string url = match.Groups["url"].Value;
                Uri uri = new UriBuilder(url).Uri;
                input = input.Replace(url, uri.AbsoluteUri);
            }
            return input;
        }
