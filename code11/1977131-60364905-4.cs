    private void btnLoadSettings_Click(object sender, EventArgs e)
    {
    	txtName.Text = Properties.Settings.Default.Name.ToString();
    	txtSchool.Text = Properties.Settings.Default.School.ToString();
    	txtClass.Text = Properties.Settings.Default.Class.ToString();
    }
