    string[] rawHtmlLines = File.ReadAllLines(@"C:\default.aspx");
    string filteredHtml = String.Join(Environment.NewLine, 
        rawHtmlLines.Where(line => !line.Contains("_VIEWSTATE")).ToArray());
    string emailPattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
    var emailMatches = Regex.Matches(filteredHtml, emailPattern);
    
    foreach (Match match in emailMatches)
    {
        //...
    }
