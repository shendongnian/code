    System.Text.RegularExpressions.Regex regexVersion = new System.Text.RegularExpressions.Regex(@".*(?<v>\d+.\d+.\d+.\d+).*");
    System.Text.RegularExpressions.Match regexVersion_Match = regexVersion.Match(System.Reflection.Assembly.GetExecutingAssembly().FullName);
    string appVersion = "";
    if (regexVersion_Match.Success)
    	appVersion = regexVersion_Match.Groups["v"].Value;
