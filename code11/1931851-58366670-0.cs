 private void BoatSubmitButton_Click(object sender, EventArgs e)
        {
            string tempTextBox = BoatNameTextBox.Text;
            string licenseVariable = BoatLicenseTextBox.Text;
            string intVariable = MaximumLoadTextBox.Text;
            boatOne = new Fleet(tempTextBox, licenseVariable, intVariable);
            BoatNameTextBox.Text = boatOne.GetboatName();
            BoatLicenseTextBox.Text = boatOne.GetboatLicense();
            MaximumLoadTextBox.Text = boatOne.GetmaximumLoad();
            BoatNameTextBox.Text = "1";
            BoatLicenseTextBox.Text = "1";
            MaximumLoadTextBox.Text = "1";
        }
