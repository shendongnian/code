    string[] lines = richTextBox2.Text.Split('\n');
    string masterLine = "";
    for( int i = 0; i < lines.Length; i ++ )
    {
        lines[i] = lines[i].Trim(); //remove white space
        lines[i] = lines[i].substring(0, lines[i].LastIndexOf(' ');
        masterLine += lines[i] + Environment.NewLine;
    }
