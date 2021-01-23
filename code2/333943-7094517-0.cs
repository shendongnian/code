    protected void btnAddToMyFList_Click(object sender, EventArgs e)
    {
      Button btnAddToMyFList = (Button)sender;
      Label label = (Label)btnAddToMyFList.Parent.FindControl("LabelId");
      String labelText = label.Text; //userName of clicked row
    }
