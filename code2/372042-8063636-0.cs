    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            // Display the e-mail address in italics.
            Label lblProdID = (Label)e.Item.FindControl("lblProdID");
            
            // Here, lblProdID contains your data ProductID as text, change to "My Text"
            lblProdID.Text = "My Text";
            DataRowView rowView = e.Item.DataItem as DataRowView;
            string myProductID = rowView["ProductID"].ToString();
            // Here, you can access your data
        }
    }
