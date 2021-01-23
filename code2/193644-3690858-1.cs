    protected void Page_Load(object sender, EventArgs e)
    {
        //Code to fetch IP address of user begins
        string userHost = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (String.IsNullOrEmpty(userHost) ||
            String.Compare(userHost, "unknown", true) == 0)
        {
            userHost = Request.Params["REMOTE_ADDR"];
        }
        Label1.Text = userHost;
        var country = Country.GetCountry(userHost);
        if (country != null)
        {
            Label2.Text = country.Name;
            Label3.Text = country.Iso3166TwoLetterCode;
        }
    }
