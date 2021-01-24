    protected void btnAdd0_Click(object sender, EventArgs e)
    {
      Button btnClicked = (Button)sender;
      string buttonClientID = btnClicked.ClientID;
      buttonClientID = buttonClientID.Split('_').Last();
      int buttonRowIndex = 0;
      int.TryParse(buttonClientID, out buttonRowIndex);
      GridViewRow row = gridViewItems0.Rows[buttonRowIndex];
      TextBox txtCurrentQty = row.FindControl("txtQty0") as TextBox;
      System.Diagnostics.Debug.WriteLine("ClientID: " + txtCurrentQty.ClientID);
      System.Diagnostics.Debug.WriteLine("Text: " + txtCurrentQty.Text);
    }
