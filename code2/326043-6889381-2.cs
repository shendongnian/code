    List<Country> countries = new List<Country>();
    countries.Add(new Country { Id = 0, Name = "Amerkia" });
    countries.Add(new Country { Id = 1, Name = "England" });
    // and so on or even better get this from some external store using a query
    
    DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
    // Now you can use the CheckBoxColumn datasource:
    col.DataSource = countries;
    // And you set the Display and value members and the DataPropertyName:
    col.DisplayMember = "Name";
    col.ValueMember = "Id";
    col.DataPropertyName = "CountryId";
    
