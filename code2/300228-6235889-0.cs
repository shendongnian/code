     protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int count = 0;
                // set count = your datatable count 
                DropDownList ddl = (DropDownList)e.Item.FindControl("ddl");  
                for(int i=1;i<=count;i++)
                {
                    ddl.Items.Add(i.ToString());    
                }
    
            }
        }
