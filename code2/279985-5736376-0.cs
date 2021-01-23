    protected void Page_Load(object sender, EventArgs e)
    {
        this.CountryControl.CountryDropDown.SelectedIndexChanged += new EventHandler(CountryDropDown_SelectedIndexChanged);
    }
    protected void CountryList_SelectedIndexChanged(object sender, EventArgs e)
    {
        // do your databinding here
    }
