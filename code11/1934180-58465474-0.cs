List<Fleet> boatList = new List<Fleet>();
DataTable dt2 = new DataTable();
private Fleet currentBoat;
private int boats = 0;
private void BoatSubmitButton_Click(object sender, EventArgs e)
{
    string licenseVariable = BoatLicenseTextBox.Text;
    string intVariable = MaximumLoadTextBox.Text;
    if (BoatNameTextBox.Text == "")
    {
        MessageBox.Show("Please Input Name", "ERROR", MessageBoxButtons.OK, 
        MessageBoxIcon.Error);
    }
    else
    {
        boatList.Add(new Fleet(BoatNameTextBox.Text, licenseVariable, 
        intVariable));
        currentBoat = boatList[boats];
        dt2.Rows.Add(new object[] { currentBoat.GetboatName(), 
        currentBoat.GetboatLicense(), currentBoat.GetmaximumLoad() });             
    }
    BoatNameTextBox.Text = "";
    BoatLicenseTextBox.Text = "";
    MaximumLoadTextBox.Text = "";
    boats++;
}
