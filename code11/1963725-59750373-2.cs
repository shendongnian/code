    var hypLink = new HyperLink
    {
        Text = "Order Nummer",
        NavigateUrl = "~/Order.Page.aspx?OrderID=00001001"
    };
        hypLink.Attributes.Add("onclick", "window.close()")
