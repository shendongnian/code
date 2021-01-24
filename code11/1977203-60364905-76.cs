    private void btnLoadSettings_Click(object sender, EventArgs e)
    {
    	txtName.Text = Properties.Settings.Default.Name;
    	txtSchool.Text = Properties.Settings.Default.School;
    	txtClass.Text = Properties.Settings.Default.Class;
    }
