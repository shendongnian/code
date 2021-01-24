    var singlelineText = singlelineTextBox.Text;
    var composedLines = new List<string>();
    for (var i = 0; i < multilineineTextBox.LineCount; i++)
    {
      composedLines.Add(singlelineText + multilineineTextBox.GetLineText(i));
    }
    
    result.Text = string.Join(EnvironmentNewline, composedLines);
