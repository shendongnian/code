    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (Controls c in pnl1.Controls)
        {
             if (c is Telerik.Web.UI.RadEditor)
             {
                  // do you stuff ...
             }
        }
    }
