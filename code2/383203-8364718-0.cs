    private void gridClientAccounts_ItemDataBound(object sender, DataGridItemEventArgs e)
      {
         if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
         {
            DataRowView myRow = (DataRowView)e.Item.DataItem;
            var unlockButton = (HyperLink)e.Item.FindControl("nameId");
            string url = string.Format("~/folder/page.aspx?id={0}&param2={1}", myRow["clientId"], unlockButton.ClientID);
                 
            unlockButton.NavigateUrl = url ;
         }
      }
