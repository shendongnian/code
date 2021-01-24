    private void btnSaveSettings_Click(object sender, EventArgs e)
    {
    	Properties.Settings.Default.txtName = txtName.Text;
    	Properties.Settings.Default.txtSchool = txtSchool.Text;
    	Properties.Settings.Default.txtClass = txtClass.Text;
    
    	if (chkActiveStudent.Checked == true)
        {
    		Properties.Settings.Default.chkActiveStudent = true;
    	}
    
    	else
        {
    		Properties.Settings.Default.chkActiveStudent = false;
    	}
    
    	Properties.Settings.Default.Save();
    }
