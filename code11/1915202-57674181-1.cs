    protected void Page_Load(object sender, EventArgs e)
        {
            progressBar.Attributes.Add("style", "width:50%");
            progressBar.Attributes.Add("aria-valuenow", "50");
            lblPercentage.InnerText = "50%";
        }
