    protected void rptNames_ItemDataBound(object sender, RepeaterItemEventArgs e){
        //Only interested the Header and Footer rows
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem){
            Label l = ((Label)e.Item.FindControl("lGivenNames"));
            string[] arrGivenNames = ((string[])e.Item.GivenNames;
            foreach (string n in arrGivenNames){//could use a StringBuilder for a performance boost.
                l.Text += n + "&nbsp;";         //Use a regular space if using it for Winforms
            }
            //For even slicker code, replace the Label in your repeater with another repeater and bind to that. Google `nested repeater` for a how to.
        }
    }
