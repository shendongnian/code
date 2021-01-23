    /// <summary>
    /// Gets or Sets the Current Order Line
    /// </summary>
    protected OrderLine CurrentOrderLine
    {
        get
        {
            if (Session["CurrentOrderLine"] == null)
            {
                Session["CurrentOrderLine"] = new OrderLine(this.CurrentOrder);
            }
            return Session["CurrentOrderLine"] as OrderLine;
        }
        set
        {
            Session["CurrentOrderLine"] = value;
        }
    }
