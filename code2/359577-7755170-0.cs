    protected void CheckBox_selectColumns_SelectedIndexChanged(object sender, EventArgs e)
            {
                bool Is_select = false;
                foreach (ListItem listItem in CheckBox_selectColumns.Items) 
                {
                    if (listItem.Selected)
                    {
                        Is_select = true;
                    }
                
                }
    
                if (Is_select)
                {
                    foreach (ListItem listItem in CheckBox_SelectAll.Items) 
                    {
                       if (listItem.Selected)
                       {
                          listItem.slected=false;
                       }
                
                    }
                }
                
            }
    
