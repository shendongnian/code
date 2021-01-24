        string input = "2019-12-31T00:00:00.123456789+01:00";
        var regEx = new Regex(@"^(\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.(\d{1,7}))\d*");
        var match = regEx.Match(input);
        if (match != null)
        {
            input = regEx.Replace(input, "$1");
            string secondsFraction = new string('f', match.Groups[2].Value.Length);
            string format = $"yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'{secondsFraction}zzz";
            DateTime parsedDate = DateTime.ParseExact(input, format, null);
        }
