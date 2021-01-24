    protected void btnAdd0_Click(object sender, EventArgs e)
    {
      Button btnClicked = (Button)sender;
    
      int buttonRowIndex = 0;
      int.TryParse(btnClicked.ClientID.Split('_').Last(), out buttonRowIndex);
    
      GridViewRow row = gridViewItems0.Rows[buttonRowIndex];
    
      TextBox txtCurrentQty = row.FindControl("txtQty0") as TextBox;
    
      System.Diagnostics.Debug.WriteLine("ClientID: " + txtCurrentQty.ClientID);
      System.Diagnostics.Debug.WriteLine("Text: " + txtCurrentQty.Text);
    }
