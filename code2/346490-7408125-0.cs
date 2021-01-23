     List<string> selectedFirstNames = new List<string>();  
     foreach (ListItem item in ListBoxMembers.Items)
     {
         if (item.Selected)
         {
             selectedNames.Add(item.Value);
         }
    
     }  
    
    //selectedFirstNames has your list of selected first names 
