    protected void FormView1_DataBound(object sender, EventArgs e)
    {
      //check the formview mode 
      if (FormView1.CurrentMode == FormViewMode.ReadOnly)
      {
        //Check the RowType to where the Control is placed
        if (FormView1.Row.RowType == DataControlRowType.DataRow)
        {
          Label label1 = (Label)UserProfileFormView.Row.Cells[0].FindControl("Label1");
          if (label1 != null)
          {
            label1.Text = "Your text";
          }
        }
      }
    }
