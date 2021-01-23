    private void CreateHousingOptions()
    {
        cmbHousing.Items.Clear();
        foreach (string housingTypeName in Enum.GetNames(typeof(Housing))) {
            cmbHousing.Items.Add(housingTypeName);
        }
        if (cmbHousing.Items.Count > 0) {
            cmbHousing.SelectedIndex = 0;
        }
    }
