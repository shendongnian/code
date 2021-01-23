    TextBox txtFDate = e.Item.FindControl("txtFDate") as TextBox;
    TextBox txtTDate = e.Item.FindControl("txtTDate") as TextBox;
    HtmlAnchor link = e.Item.FindControl("aLink") as HtmlAnchor;
    
    if (txtTDate != null && txtFDate != null && link != null)
    {
       link.Attributes.Add("onclick", String.Format("showCalendarControl({0}, '{1}', '{2}')", 4, txtFDate.ClientID, txtTDate.ClientID);
    }
