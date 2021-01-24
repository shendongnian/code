    if (!string.IsNullOrEmpty(txtStaffId.Text))
    {
    	int salesmanId = Int32.Parse(txtStaffId.Text);
    	staff = salesmanBO.GetStaffById(salesmanId);
    
    	
    	if (staff!=null) // no need to check salesmanId == staff.StaffId as we already checked while querying it.
    	{
    		PosWindows posWindows = new PosWindows();
    		posWindows.Show();
    		this.Close();
    	}
    	else
    	{
    		MessageBox.Show("ID not Valid", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
    	}
    
    }
