    int maxAddDriver = 5;
    int addDriver = 0;
    
    private void btnNext_Click(object sender, EventArgs e)
    {
    	answer = MessageBox.Show("Would you like to add an additional driver to policy?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
    	
    	addDriver++;
    
    	Hide();  
    
    
    		//answer = MessageBox.Show("Would you like to add an additional driver to policy?",
    		//    "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
    	
    
    	if (addDriver == maxAddDriver && answer == DialogResult.Yes)
    	{
    		new frmAdditionalDriver().Show();
    	}
    	else if (addDriver == maxAddDriver || answer == DialogResult.No)
    	{
    		new frmInsurancePolicy().ShowDialog();
    	}
    
    	Show();
    }
