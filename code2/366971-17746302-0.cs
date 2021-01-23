    protected void PersonesRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            PersonLine line = (PersonLine)e.Item.FindControl("Person1");
            line.Person = e.Item.DataItem as Osoba;
        }
    }
