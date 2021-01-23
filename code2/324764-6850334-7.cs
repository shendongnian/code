    string[] lines = placementTwoListBox.Text.Split(new string[] { Environment.NewLine }, 
        StringSplitOptions.RemoveEmptyEntries);
    
    List<string> calculatedXLines = new List<string>();//to fill calculatedXRichTextBox
    List<string> calculatedYLines = new List<string>();//to fill calculatedYRichTextBox
    
    foreach (string line in lines)
    {
        //if the split between lines is tab
        string[] items = line.Split(new string[] { "\t" }, 
            StringSplitOptions.RemoveEmptyEntires);
        //if it undefined number of spaces
        string[] items = line.Split(new string[] { " " }, 
            StringSplitOptions.RemoveEmptyEntires);//note that we remove any empty strings
          
        if (items.Length > 2)
        {
            calculatedXLines.Add(items[2]);
            calculatedYLines.Add(items[3]);
        }
    }
    //add them to the calculatedYRichTextBox and the placementTwoListBox
    calculatedXRichTextBox.Text = string.Join(Environment.NewLine, calculatedXLines); 
    calculatedYRichTextBox.Text = string.Join(Environment.NewLine, calculatedYLines); 
