    // Regex Replace code for C#
    void ReplaceRegex()
    {
        // Regex search and replace
        RegexOptions   options = RegexOptions.None;
        Regex          regex = new Regex(@"\[MM\](?<value>.*)\[\/MM\]", options);
        string         input = @"[MM]1000[/MM]";
        string         replacement = @"10cm";
        string         result = regex.Replace(input, replacement);
    
        // TODO: Do something with result
        System.Windows.Forms.MessageBox.Show(result, "Replace");
    }
