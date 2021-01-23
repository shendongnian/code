    StringBuilder sb = new StringBuilder();
    foreach(ListItem item in CustomerListBox.Items)
    {
         
         If(item.selected)
         {
             sb.Append(item.SelectedValue+",");
         }
    }
