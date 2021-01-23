    string[] lines = placementTwoListBox.Text.Split(new string[] { Environment.NewLine }, 
        StringSplitOptions.RemoveEmptyEntries);
    
    List<string> calculatedX = new List<string>();//to fill calculatedXRichTextBox
    List<string> calculatedY = new List<string>();//to fill calculatedYRichTextBox
    
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
            calculatedX.Add(items[2]);
            calculatedY.Add(items[3]);
        }
    }
    //add them to the calculatedYRichTextBox and the placementTwoListBox
    calculatedXRichTextBox.Text = string.Join(Environment.NewLine, calculatedX); 
    calculatedYRichTextBox.Text = string.Join(Environment.NewLine, calculatedY); 
 
