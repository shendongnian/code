    protected void ContactsListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label EmailAddressLabel;
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                // Display the e-mail address in italics.
                EmailAddressLabel = (Label)e.Item.FindControl("EmailAddressLabel");    
                System.Data.DataRowView rowView = e.Item.DataItem as System.Data.DataRowView;
                string currentEmailAddress = rowView["EmailAddress"].ToString();
            }
