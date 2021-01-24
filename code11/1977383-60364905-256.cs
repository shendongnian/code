    private void btnLoadSettings_Click(object sender, EventArgs e)
    {
    	txtName.Text = Properties.Settings.Default.txtName.ToString();
    	txtSchool.Text = Properties.Settings.Default.txtSchool.ToString();
    	txtClass.Text = Properties.Settings.Default.txtClass.ToString();
    
    	if (Properties.Settings.Default.chkActiveStudent == true)
        {
    		chkActiveStudent.Checked = true;
    	}
    	else
        {
    		chkActiveStudent.Checked = false;
    	}
    }
