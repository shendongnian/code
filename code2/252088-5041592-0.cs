    protected void chkboxMentor_CheckedChanged(object sender, EventArgs e) 
    { 
    	 if(chkboxMentor.Checked)
    	{
    		lblMentorName.Visible = true;
    		txtMentorName.Visible = true; 
    		lblMentorStuff.Visible = true;
    		txtMentorStaffNo.Visible = true;
    		lblMentorDate.Visible = true;
    		btnShowCal.Visible = true; 
    	}
    	else
    	{
    
    		lblMentorName.Visible = false;
    		txtMentorName.Visible = false; 
    		lblMentorStuff.Visible = false;
    		txtMentorStaffNo.Visible = false;
    		lblMentorDate.Visible = false;
    		btnShowCal.Visible = false; 
    	}
    }
