    string[] calculatedXLines = calculatedXRichTextBox.Text.Split(new string[] { Environment.NewLine }, 
        StringSplitOptions.RemoveEmptyEntries);
    string[] calculatedYLines = calculatedXRichTextBox.Text.Split(new string[] { Environment.NewLine }, 
        StringSplitOptions.RemoveEmptyEntries);
     string[] lines = placementTwoListBox.Text.Split(new string[] { Environment.NewLine }, 
    StringSplitOptions.RemoveEmptyEntries);
    
    List<string[]> newLines = new List<string[]>();
    
    for (int lineIndex = 0; lineIndex < lines.Lenght; lineIndex++)
    {
        //if the split between lines is tab
        string[] items = lines[lineIndex].Split(new string[] { "\t" }, 
            StringSplitOptions.RemoveEmptyEntires);
    
        items[2] = calculatedXLines[lineIndex];
        items[3] = calculatedYLines[lineIndex];
    
        newLines.Add(items);
    }
    //represents your data on the `placementTwoListBox`:
    placementTwoListBox.Clear();
    foreach (string[] lineItems in newLines)
    {
        placementTwoListBox.Text += string.Join("\t", lineItems) + Envirunment.NewLine;
    }
    
 
