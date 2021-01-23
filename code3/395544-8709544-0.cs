    protected void MyControl_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                var label = (Label)e.Item.FindControl("lblSkill1");
                if (label != null)
                    label.Text = "Text you want to set";
            }
        }
