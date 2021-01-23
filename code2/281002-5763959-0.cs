    string doubleNewLine = Environement.NewLine+Environement.NewLine;
    while (rtfBox.Text.Contains(doubleNewLine)
    {
       refBox.Text = refBox.Text.Replace(doubleNewLine,Environement.NewLine);
    }
    // deal with special case of text box starting with newline.
    
