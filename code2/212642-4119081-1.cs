    protected void NesterRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DataRowView dataRowView = (DataRowView)e.Item.DataItem;
    
            PlaceHolder phNoAdmin = e.Item.FindControl("phNoAdmin") as PlaceHolder;
            PlaceHolder phAdmin = e.Item.FindControl("phAdmin") as PlaceHolder;
            string memberInGroup = Convert.ToString(dataRowView["userEmail"]);
            currentRenderedUser = memberInGroup;
            if (CheckIfUserIsAdmin(email, currentRenderedGroup))
            { 
                if (CheckIfUserIsAdmin(currentRenderedUser, currentRenderedGroup))
                {
                    phNoAdmin.Visible = true;
                    phAdmin.Visible = false;
                }
                else
                {
                    phNoAdmin.Visible = false;
                    phAdmin.Visible = true;
                }
            }            
        }
    }
