    foreach (Item item in myItemsList)
    {
       if (item.Name == string.Empty)
       {
          // Display error message and move to next item in list.  Skip/ignore all validation
          // that follows beneath
          continue;
       }
    
       if (item.Weight > 100)
       {
          // Display error message and move to next item in list.  Skip/ignore all validation
          // that follows beneath
          continue;
       }
    }
