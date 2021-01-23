    private void cb_bank_code_SelectedIndexChanged(object sender, EventArgs e)
    {  
       ClearTextfieldsAfterInput();
             
       branchMasterBindingSource.DataSource = GetSelectedBranchMasters();
   
       var bankMasters = GetSelectedBankMaster();
       if (bankMasters.Any(x => x != null))
       {
    	   var bankMaster = bankMasters.First();
	   
    	   lbl_show_bank_name.Text = bankMaster.U_Bank_name;
    	   CbBankCode = bankMaster.U_Bank_code;
       }
       else
       {
    	   //clear textfields after input
    	   lbl_show_bank_name.Text = string.Empty;
       }
    }
    private IEnumerable<BankMaster> GetSelectedBankMaster()
    {
        var selectedBank = cb_bank_code.Text.Trim();
    	return Program.Kernel.Get<IBankMasterService>()
    		.GetAllBankMasters()
       		.Where(bm => bm.U_Bank_code.Trim().Equals(selectedBank, StringComparison.CurrentCultureIgnoreCase)
	    	.ToList();
    }
    private IEnumerable<BranchMaster> GetSelectedBranchMasters()
    {
        var selectedBank = cb_bank_code.Text.Trim();
    	return Program.Kernel.Get<IBranchMasterService>()
    		.GetAllBranchMasters()
    		.Where(branch => string.Equals(branch.U_bank_code, selectedBank, StringComparison.CurrentCultureIgnoreCase)
    		.ToList();
    }
    private void ClearTextfieldsAfterInput()
    {
       lbl_show_bank_name.Text = "";
       txt_branch_code.Text = "";
       txt_branch_name.Text = "";
       txt_swift_sort_code.Text = "";
       txt_address_1.Text = "";
       txt_address_2.Text = "";
       txt_comments.Text = "";
    }
