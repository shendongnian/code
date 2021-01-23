        string input = "My link: [url=\"http://www.something.com\"]Some text[/url] is awesome. Jazz hands activate!!";
        string regex = @"\[([^=]+)[=\x22']*(\S*?)['\x22]*\](.+?)\[/(\1)\]";
        MatchCollection matches = new Regex(regex).Matches(input);
        for (int i = 0; i < matches.Count; i++)
        {
            var tag = matches[i].Groups[1].Value;
            var optionalValue = matches[i].Groups[2].Value;
            var content = matches[i].Groups[3].Value;
            var closingTag = matches[i].Groups[4].Value; //pattern makes sure that this equals starting tag
        }
