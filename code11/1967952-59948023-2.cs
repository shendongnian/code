    const string sent = "RadMessageBox.Show(Translate(\"Problem with arguments\"), Translate(\"Error!\"), Translate(\"Bad digital format, it must be of the form 112.3456E12.\"), MessageBoxButtons.OK, RadMessageIcon.Error);";
    const string pattern = "([\"'])(?:\\1|.)*?\\1";
    
    var results = Regex.Matches(sent, pattern);
    var sb = new StringBuilder();
    foreach (var match in results)
    {
        sb.Append(match.ToString().Trim('"') + " ");
    }
    Console.WriteLine(sb.ToString());
