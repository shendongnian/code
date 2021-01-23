    string[] calculatedYLines = calculatedYRichTextBox.Text.Split(new string[] { "\n", "\r" },
        StringSplitOptions.RemoveEmptyEntries);
    string[] lines = new string[placementTwoListBox.Items.Count];
    for (int itemIndex = 0; itemIndex < lines.Length; itemIndex++)
    { 
        lines[itemIndex] = placementTwoListBox.Items[itemIndex].ToString();
    }
    List<string[]> newLines = new List<string[]>();
    for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
    {
        string[] items = lines[lineIndex].Split(new string[] { " ", "\t" },
            StringSplitOptions.RemoveEmptyEntries);
        items[2] = calculatedXLines[lineIndex];
        items[3] = calculatedYLines[lineIndex];
        newLines.Add(items);
    }
    //represents your data on the `placementTwoListBox`:
    placementTwoListBox.Items.Clear();
    foreach (string[] lineItems in newLines)
    {
        placementTwoListBox.Items.Add(string.Join("\t", lineItems));
    }
 
