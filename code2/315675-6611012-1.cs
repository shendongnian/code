    protected void rbl_MinCriteria_SelectedIndexChanged(object sender,EventArgs e)
    {
       if (rbl_MinCriteria.SelectedIndex<0) return; //If nothing is selected then do nothing
    
           OtherControlI.Enabled = false;
           OtherControlII.Enabled = false;
           OtherControlIII.Enabled = false;
       if(rbl_MinCriteria.SelectedItem.ToString() == "All provided")
       {
           cbl_MinimumCriteria.Items[0].Selected = true;
           cbl_MinimumCriteria.Items[1].Selected = true;
           cbl_MinimumCriteria.Items[2].Selected = true;
           cbl_MinimumCriteria.Items[3].Selected = true;
           cbl_MinimumCriteria.Enabled = false;
    
       }
       if (rbl_MinCriteria.SelectedItem.ToString() == "Some provided")
       {
           cbl_MinimumCriteria.Items[0].Selected = false;
           cbl_MinimumCriteria.Items[1].Selected = false;
           cbl_MinimumCriteria.Items[2].Selected = false;
           cbl_MinimumCriteria.Items[3].Selected = false;
           cbl_MinimumCriteria.Enabled = true;
    
           OtherControlI.SelectedIndex = -1;
           OtherControlII.SelectedIndex = -1;
           OtherControlIII.SelectedIndex = -1;
       }
    
       //*************************************************************
       if (ddl_CountryOccurence.SelectedValue != "Please choose")
       {
           ddl_CountryOccurence.Enabled = false;
       }
       else
       {
           ddl_CountryOccurence.Enabled = true;
       }
       //*************************************************************
       if (tb_DueDate.Text != "")
       {
         tb_DueDate.Enabled = false;
       }
       else
       {
           tb_DueDate.Enabled = true;
       }
    }
