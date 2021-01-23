        protected void TheRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (ListItemType.Item == e.Item.ItemType || ListItemType.AlternatingItem == e.Item.ItemType)
            {
                NameValuePair nvp = (NameValuePair)e.Item.DataItem;
                PlaceHolder container = (PlaceHolder)e.Item.FindControl("ValuePlaceHolder");
                if (typeof(nvp.Value) is String)
                {
                    Literal textControl = new Literal() { Mode = LiteralMode.Encode, Text = (string)nvp.Value, EnableViewState = false };
                    container.Controls.Add(textControl);
                }
                ...
