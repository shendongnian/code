    if(e.Clicks>1)
    {
       int index = fieldsArea.IndexFromPoint(e.Location);
       string s = fieldsArea.Items[index].ToString();
       selectedFieldsArea.Items.Add(s); 
    }
               
