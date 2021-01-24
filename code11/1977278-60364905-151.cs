    private void btnLoadSettings_Click(object sender, EventArgs e)
    {
    	txtName.Text = Properties.Settings.Default.txtName;
    	txtSchool.Text = Properties.Settings.Default.txtSchool;
        txtClass.Text = Properties.Settings.Default.txtClass;
        
        if (Properties.Settings.Default.chkActiveStudent == true)
            {
                chkActiveStudent.Checked = true;
            }
            else
            {
                chkActiveStudent.Checked = false;
            }
    }
