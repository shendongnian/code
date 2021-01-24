    public void Form1_Load(object sender, EventArgs e)
    {
        BoatDataGridView.DataSource = new BindingList<Fleet>();
    }
    private void BoatSubmitButton_Click(object sender, EventArgs e)
    {
        Fleet boat = new Fleet(BoatNameTextBox.Text, BoatLicenseTextBox.Text, MaximumLoadTextBox.Text;);
        BindingList<Fleet> bs = BoatDataGridView.DataSource as BindingList<Fleet>;
        bs.Add(boat);
        BoatNameTextBox.Text = "";
        BoatLicenseTextBox.Text = "";
        MaximumLoadTextBox.Text = "";
    }
