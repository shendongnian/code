            protected void repLinks_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item.DataItem as objInnovationListItem;
            ((Label) e.Item.FindControl("lblProject")).Text = item.Name;
            ((HyperLink) e.Item.FindControl("hlLink")).NavigateUrl = string.Format("/downloaduri?id={0}", item.Title);
        }
