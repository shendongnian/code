    public void btSubmit_Click(object sender, EventArgs e)
    {
      foreach (GridViewRow row in CustomersGridView.Rows) 
      {
        CheckBox cbVerify = (CheckBox)row.FindControl("cbVerify");
        HiddenField hidID = (HiddenField)row.FindControl("hidID");
    
        // Do your validation of the data here
        ..
    
        if (cbVerify != null)
        {
          // Add fields and update
          sqlRecord.UpdateParameters["ID"].DefaultValue = hidID.Value;
          sqlRecord.UpdateParameters["Valid"].DefaultValue = cbVerify.Checked.ToString();
          sqlRecord.Update();
        }
    }
