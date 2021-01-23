    protected void Page_Load(object sender, EventArgs e)
        {
            if (FileTypeDDL.SelectedValue == "Agency") { AgencyGrid(); }
            else if (FileTypeDDL.SelectedValue == "Stops") { StopsGrid(); }
        }
