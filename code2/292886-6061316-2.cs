        string test = "you've selected :";
        foreach (ListItem item in theCheckBoxList.Items)
        {
            test += item.Selected ? item.Value + ", " : "";
        }
        labelResult.Text = test;
 
