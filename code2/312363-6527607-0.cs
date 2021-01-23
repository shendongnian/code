        protected void repAnnualReport_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            CurrentYear = int.Parse(((Literal)e.Item.FindControl("litLicenseYear")).Text);
    
            Repeater repLicenseLengths = (Repeater)e.Item.FindControl("repLicenseLengths");
            repLicenseLengths.DataSource = GetLicenseLengths(CurrentYear);
            repLicenseLengths.DataBind();
        }
    
        protected void repLicenseLengths_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            CurrentLength = int.Parse(((Literal)e.Item.FindControl("litLicenseLength")).Text) * 365;
    
            Repeater repMonthlyReport = (Repeater)e.Item.FindControl("repMonthlyReport");
            repMonthlyReport.DataSource = new object[12];
            repMonthlyReport.DataBind();
        }
