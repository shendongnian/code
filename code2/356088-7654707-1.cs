    public void btSubmit_Click(object sender, EventArgs e)
    {
      // Do your validation of the data here
      ..
    
      // Add fields and insert
      sqlRecord.InsertParameters["Field1"].DefaultValue = ddlField1.SelectedValue;
      sqlRecord.InsertParameters["Comment"].DefaultValue = tbComment.Text;
      sqlRecord.Insert();
    }
