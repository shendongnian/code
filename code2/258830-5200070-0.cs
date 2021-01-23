    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataRowView drw = (DataRowView)e.Item.DataItem
            String sql = String.Format("Select * FROM UserInfo WHERE user_id={0}", drw["user_id"]);
    
            
            Label lblUserName = (Label) e.Item.FindControl("lblUserName");
            lblUserName.Text = //WWhatever you get from query...
        }
