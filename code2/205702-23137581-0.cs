    private int Search_Item_Return_Index(ComboBox combo, string Search)
         {
             int index=-1;
    
             foreach (ComboBoxItem item in combo.Items)
             {
                 index++;
                 string var = item.Content.ToString() ;
                 if (var.Equals(Search))
                 {
                     return index;
                 }
                 
             }
    
    
             return index;
    
         }
