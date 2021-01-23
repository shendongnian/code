        protected void ShowHideHeaderFooter(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Header && theDataSource.Count == 0 && !ShowHeaderOnEmpty)
            {
                e.Item.FindControl("PlaceHolderHeader").Visible = false;
            }
            ...
        }
