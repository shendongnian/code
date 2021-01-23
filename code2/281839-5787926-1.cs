    protected void Page_Load(object sender, EventArgs e)
    {
        ...	
    }
    protected void CountryList_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCityList(CountryList, CityList);
    }
