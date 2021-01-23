        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater parentRepeater;
                // e.Item: the item/header/whatever template that kicked off this event
                // e.Item.NamingContainer: the owner of the item template (the innner repeater)
                // e.Item.NamingContainer.NamingContainer: the outer item template
                // e.Item.NamingContainer.NamingContainer.NamingContainer: the outer Repeater
                parentRepeater = (Repeater)e.Item.NamingContainer.NamingContainer.NamingContainer;
            }
        }
