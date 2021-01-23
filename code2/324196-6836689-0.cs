    double d = double.Parse(xDisplacementTextBox.Text);
    string[] Lines = xRichTextBox.Text.Split('\n');
    for(int i = 0; i < Lines.Length; ++i)
    {
        Match lineMatch = Regex.Match(lines[i], @"^(?<p>.*)(?<x>-?\d+\.\d+)(?<y>\s+-?\d+\.\d+\s+-?\d+\.\d+)$");
        if (lineMatch.Success)
        {
            double xValue = double.Parse(lineMatch.Groups["x"].Value) + d;
            lines[i] = lineMatch.Groups["p"] + xValue + lineMatch.Groups["p"];
        }
     }
     xRichTextBox.Text = string.Join(lines, '\n');
