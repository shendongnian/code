    string[] lines = placementTwoListBox.Text.Split(new string[] { Environment.NewLine }, 
        StringSplitOptions.RemoveEmptyEntries);
    
    List<string> calculated = new List<string>();//calculatedYRichTextBox
    List<string> placement = new List<string>();//placementTwoListBox 
    
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
            calculated.Add(items[2]);
            placement.Add(items[3]);
        }
    }
    //add them to the calculatedYRichTextBox and the placementTwoListBox
    calculatedYRichTextBox.Text = string.Join(Environment.NewLine, calculated); 
    placementTwoListBox .Text = string.Join(Environment.NewLine, placement); 
 
