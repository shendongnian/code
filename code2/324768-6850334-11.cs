    string[] lines = new string[placementTwoListBox.Items.Count];
    for (int itemIndex = 0; itemIndex < lines.Length; itemIndex++)
    { 
        lines[itemIndex] = placementTwoListBox.Items[itemIndex].ToString();
    }
    List<string> calculatedXLines = new List<string>();//to fill calculatedXRichTextBox
    List<string> calculatedYLines = new List<string>();//to fill calculatedYRichTextBox
    
    foreach (string line in lines)
    {
        string[] items = line.Split(new string[] { "\t", " " }, 
            StringSplitOptions.RemoveEmptyEntires);
        if (items.Length > 2)
        {
            calculatedXLines.Add(items[2]);
            calculatedYLines.Add(items[3]);
        }
    }
    //add them to the calculatedYRichTextBox and the placementTwoListBox
    calculatedXRichTextBox.Text = string.Join("\n", calculatedXLines); 
    calculatedYRichTextBox.Text = string.Join("\n", calculatedYLines); 
