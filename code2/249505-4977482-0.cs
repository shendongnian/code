      private void CreateHousingOptions()
            {
                string[] housingTypeNames = Enum.GetNames(typeof(Housing));
                cmbHousing.Items.Clear();
            for (int rbIndex = 0; rbIndex < housingTypeNames.Length; rbIndex++)
            {
                cmbHousing.Items.Add(housingTypeNames[rbIndex]);
            }
            cmbHousing.SelectedItem = housingTypeNames[0];
        }
