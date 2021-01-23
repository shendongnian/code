    protected void BindTabStrip()
    {
        DataSet ds = GetDataSetForTabs();
        RadTabStrip1.AppendDataBoundItems = true;
        RadTabStrip1.DataSource = ds;
        RadTabStrip1.DataTextField = "QuesType";
        RadTabStrip1.DataValueField = "QuesTypeID";
        RadTabStrip1.DataBind();
 
        // Remove it accordian from the page before adding it to 
        // a new ControlCollection
        Page.Controls.Remove(Accordian1); 
        RadPageView pv = new RadPageView();
        pv.Controls.Add(Accordion1);
        RadMultiPage1.PageViews.Add(pv);
    }
