    private class City
    {
        public string Name { get; set; }
    }
    
    private void cmbCountryValues_SelectedIndexChanged(object sender, EventArgs e)
    {
        dgvCityValues.Enabled = cmbCountryValues.SelectedIndex >= 0;
        if (!dgvCityValues.Enabled)
        {
            dgvCityValues.DataSource = null;
            return;
        }
    
        int CountryId = int.Parse(cmbCountryValues.SelectedValue.ToString());
    
        var queryResults = from record in Program.dal.Cities(CountryId) select new City { Name = record.City };
        var queryBinding = new BindingList<City>(queryResults.ToList());
        queryBinding.AllowNew = true;
    
        dgvValues.DataSource = queryBinding;
    }
