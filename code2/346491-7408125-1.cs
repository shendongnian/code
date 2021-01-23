     List<string> selectedFirstNames = new List<string>();  
     foreach (ListItem item in ListBoxMembers.Items)
     {
         if (item.Selected)
         {
             selectedFirstNames.Add(item.Value);
         }
    
     }  
    
    //selectedFirstNames has your list of selected first names 
